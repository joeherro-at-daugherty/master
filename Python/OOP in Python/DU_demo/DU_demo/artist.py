class Artist():

    def __init__(self, name, albums=None):
        self.name = name
        if albums is None:
            self.albums = []
        else:
            self.albums = albums

    def countSongs(self):
        cnt = sum([len(album.songs) for album in self.albums])  # opportunity to demonstrate list comprehension AND/OR composition?
        return cnt
