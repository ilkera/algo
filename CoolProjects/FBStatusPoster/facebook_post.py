# Script to post a status update to Facebook
import urllib.request
import urllib.parse
import json

class HttpRequest:
    encoding = "UTF-8"

    def post(self, url, data):
        encoded_args = urllib.parse.urlencode(data).encode(self.encoding)
        response = urllib.request.urlopen(url, encoded_args)
        print(response.read())

class FacebookAPIManager:
    access_token = "PUT_YOUR_ACCES_TOKEN"

    def postStatusUpdate(self, fbPost):
        print("Sending post to facebook")
        params = {'message': fbPost.message, 'access_token': self.access_token}
        url = "https://graph.facebook.com/%s/feed?" % fbPost.postTo
        request = HttpRequest()
        request.post(url, params)

class FBStatusPost:
    message = None
    postTo = None
    def __init__(self, user, message):
        self.postTo = user
        self.message = message

# Client
#ergin - 711666637
fbPost = FBStatusPost("me","Selam naber")
fbApiManager = FacebookAPIManager()
fbApiManager.postStatusUpdate(fbPost)
