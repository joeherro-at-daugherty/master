class Song():

    def __init__(self, name, duration, release_date):
        self.name = name
        self.duration = duration
        self.release_date = release_date

    #a special method used to represent a class's objects as a string.
    #customary for debugging
    def __repr__(self):
        return self.name
