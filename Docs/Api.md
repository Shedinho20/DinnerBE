# Dinner API

##### Table of Contents

- [Dinner API](#dinner-api)

  - [Auth](#auth)

    - [Register](#register)

      - [Register request](#register-request)

      - [Register response](#register-response)

    - [Login](#login)

      - [Login request](#login-request)

      - [Login response](#login-response)

##Auth

##Register

```javascript
Post {{host}/auth/register}
```

#### Register Request

```json
{
  "firstName": "Shedrach",
  "lastName": "Ezenwali",
  "email": "shedr@gmail.com",
  "password": "Desinho20@",
  "confirmPassword": "Desinho20@"
}
```

#### Regsister Response

```json
{
  "id": "id-GUID",
  "firstName": "Shedrach",
  "lastName": "Ezenwali",
  "email": "shedr@gmail.com",
  "token": "djjdjljrjj4kj4jj4jkfshkh4"
}
```

##Login

```javascript
Post {{host}/auth/login}
```

#### Login Request

```json
{
  "email": "shedr@gmail.com",
  "password": "Desinho20@"
}
```

#### Login Response

```json
{
  "id": "id-GUID",
  "firstName": "Shedrach",
  "lastName": "Ezenwali",
  "email": "shedr@gmail.com",
  "token": "djjdjljrjj4kj4jj4jkfshkh4"
}
```
