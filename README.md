# FeedAggregaror
ASP.NET Core Web API. Provides news streams from different sources. 

#### User collections
User collections has two fields: string UserId for user identification and list of Feed.
Feed has info about chanel and list of items. It is user for updating news every 15 minutes.
It is implemented by launching background job every 15 minutes.
Also here is simple console client as an example of api usage.

### Methods
Returns collection with user Id

`GET: /api/collections/:id`

Returns new collection with user Id

`POST /api/collections`

Deletes collection with such id

`DELETE /api/collection/:id`

Returns feed with such id

`GET /api/feed/:id`

Subscribes news to user with such id

`POST /api/feed/:id`

JSON : 

`{
"userId": "string id",`

`"feedType": "RSS",`

`"chanellUrl": "urlToSource"
}`

Unsubscribes news with such id from user

`DELETE /api/feed/:id`


