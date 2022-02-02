from datetime import timedelta

class Album():

    def __init__(self, title, release_date, songs=None):
        self.title = title
        self.release_date = release_date
        if songs is None:
            self.songs = []
        else:
            self.songs = songs

    #a special method used to represent a class's objects as a string.
    #customary for debugging
    def __repr__(self):
        return self.title

    def countSongs(self):
        return len(self.songs)

    def totalDuration(self):
        time = sum([song.duration for song in self.songs], timedelta())
        return time
