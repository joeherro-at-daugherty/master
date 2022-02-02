from album import Album #abstractions provide standard interface for multiple components
from artist import Artist
from song import Song
from datetime import timedelta, datetime
from csv import DictReader


def read_content(filename):
    with open(filename, newline='') as fp:
        reader = DictReader(fp)
        return list(reader)

def create_object(record, constructor):
    if 'release_date' in record:
        record['release_date'] = datetime.fromisoformat(record['release_date'])
    if 'duration' in record:
        h, m, s = record['duration'].split(':')
        record['duration'] = timedelta(
            hours=int(h), minutes=int(m), seconds=int(s))
    if 'key' in record:
        record = {k: v for k, v in record.items() if k != "key"}
    return constructor(**record)

def init_objects(types):
    database = {}
    for obj, c in types:
        #read content
        data = read_content(f'data/{obj}.csv')
        #create instance in iterative manner
        lookup = {record['key']: create_object(record,c) for record in data}
        database[obj] = lookup
    return database

def add_relationships(database, relationship_types):
    for parent_type, child_type in relationship_types:
        data = read_content(
            f'data/{parent_type}_x_{child_type}.csv')
        for relationship in data:
            parent_key = relationship[parent_type]
            child_key = relationship[child_type]
            parent = database[parent_type][parent_key]
            parent.__getattribute__(child_type).append(child_key)

def load():
    #initialize objects
    database = init_objects([
        ('artists',Artist),
        ('albums',Album),
        ('songs',Song)
    ])
    #create relationships between objects
    add_relationships(database,[
        ('artists','albums'),
        ('albums','songs')
    ])
    return database

def get_stats(x, indent=0):
    stats = '\t'*indent
    if isinstance(x, Artist):
        stats += 'Artist: {}, # of Albums: {}'.format(x.name, len(x.albums))
    elif isinstance(x, Album):
        stats += 'Album: "{}", # of Songs: {}'.format(x.title, x.countSongs())
    return stats

def analyze(database):
    for artist in database['artists'].values():
        print(get_stats(artist))
        for album in artist.albums:
            print(get_stats(database['albums'][album], indent=1))

#main program
if __name__ == "__main__":
    database = load()
    analyze(database)