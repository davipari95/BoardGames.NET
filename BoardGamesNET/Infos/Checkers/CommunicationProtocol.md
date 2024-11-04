# [Checkers] Communication Protocol

Every command must be sent with CRLF (`\r\n`).<br/>
Every time there is a success, command must be sent `ACK\r\n` and a secondary response, ended with `\r\n`.<br/>
In case there is an error, server (or client) must responds with `ERR-<code_nr>`.<br/>
Encoding is in **UNICODE**.

## From server to client

## From client to server

### `set-user-name [<username>]`
Set the username of the client.<br/>

#### Parameters
- `<username>`: username of the client. Must be sent between brackets (`[]`).

#### Responses
- `ACK`: command received correctly.
	- `<username>`: the same username passed as parameter.

#### Examples

##### Example 1
>Set username "foo".
>```text
>>> set-user-name [foo]\r\n
><< ACK\r\nfoo\r\n
>```