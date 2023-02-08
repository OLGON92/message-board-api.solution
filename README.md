# Message Board API
This API provides CRUD operations for a message board. It was built using the following technologies:
- ASP.NET Core
- Entity Framework Core
- MVC
- JSON Patch
- API Versioning

## Endpoints
### Retrieve All Messages
`GET api/v2/messages`

This endpoint retrieves all messages stored in the database. You can filter the messages returned by passing in query parameters for comment, group, and userName.

### Retrieve a Specific Message
`GET api/v2/messages/{id}`

This endpoint retrieves a specific message with the given id. If no message is found with the given id, a `404 Not Found` error is returned.

### Create a New Message
`POST api/v2/messages`

This endpoint creates a new message. The body of the request should contain the information for the new message.

### Update a Message
`PUT api/v2/messages/{id}`

This endpoint updates a message with the given id. The body of the request should contain the updated information for the message. If no message is found with the given id, a `404 Not Found` error is returned.

### Delete a Message
`DELETE api/v2/messages/{id}`

This endpoint deletes a message with the given id. If no message is found with the given id, a `404 Not Found` error is returned.

## Pagination
The `GET api/v2/messages` endpoint also supports pagination. By default, it returns all messages in the database. To retrieve a specific page of messages, add `?page={pageNumber}` to the end of the URL. The number of messages per page can be changed from the default of 10 to any other number by adding `&pageSize={number}` to the URL. For example, to retrieve the second page with 5 messages per page, the URL would be `GET api/v2/messages?page=2&pageSize=5`.
