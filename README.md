# API specifikacija

### POST /register

Sukuria naują naudotoją su nurodytais parametrais

#### Metodo URL

`http://localhost:5259/api/register`

#### Atsakymų kodai

| Pavadinimas | Kodas |
| ----------- | ----- |
| No Content  | 201   |
| Bad request | 400   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas          | Pavyzdys            |
| ----------- | ----------- | --------------------- | --------------------|
| username    | Taip        | Naudotojo vardas      | `naudotojasAdmin`   |
| password    | Taip        | Naudotojo slaptažodis | `Slaptazodis123?`   |
| email       | Taip        | Naudotojo Paštas      | `armign@pastas.com` |

#### Užklausos pavyzdys

`POST http://localhost:5259/api/register`

```
{
  "password": "string",
  "userName": "string",
  "email": "string"
}
```

#### Atsakymo pavyzdys

```
{
  "id": "string",
  "username": "string",
  "email": "string",
}
```

### POST /login

Gražina naudotojo sugeneruotą žetoną, kuris vėliau yra naudojamas atpažinti naudotojo rolei

#### Metodo URL

`http://localhost:5259/api/login`

#### Atsakymų kodai

| Pavadinimas | Kodas |
| ----------- | ----- |
| OK          | 200   |
| Bad request | 400   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas          | Pavyzdys          |
| ----------- | ----------- | --------------------- | ------------------|
| username    | Taip        | Naudotojo vardas      | `userAdmin`       |
| password    | Taip        | Naudotojo slaptažodis | `Slaptazodis123?` |

#### Užklausos pavyzdys

`POST http://localhost:5259/api/login`

```
{
  "username": "string",
  "password": "string"
}
```

#### Atsakymo pavyzdys

```
{
    "accessToken" : "string"
}
```

## Kategorijų API metodai

### GET /categories

Gražina sąrašą visų kategorijų

#### Metodo URL

`http://localhost:5259/api/categories`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Unauthorized | 401   |

#### Užklausos pavyzdys

`GET http://localhost:5259/api/categories`

#### Atsakymo pavyzdys

```
[
    {
        "id": 9,
        "name": "Nuomai",
        "description": "NT nuomai"
    },
    {
        "id": 10,
        "name": "Isperkamajai nuomai",
        "description": "NT isperkamajai nuomai"
    }
]
```

### GET /categories/{id}

Gražina kategoriją pagal id, kuris perduodamas per URL

#### Metodo URL

`http://localhost:5259/api/categories/{id}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Not found    | 404   |

#### Užklausos pavyzdys

`GET  http://localhost:5259/api/categories/9`

#### Atsakymo pavyzdys

```
{
    "id": 9,
    "name": "Nuomai",
    "description": "NT nuomai"
}
```

### POST /categories

Sukuria kategoriją nurodytais parametrais, funkcija prieinama tik administratoriui

#### Metodo URL

`http://localhost:5259/api/categories`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| Created      | 201   |
| Bad request  | 400   |
| Unauthorized | 401   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas             | Pavyzdys             |
| ----------- | ----------- | -------------------------| -------------------- |
| name        | Taip        | Kategorijos pavadinimas  | `Pardavimui`         |
| description | Taip        | Gyvūno tipas             | `NT pardavimui`      |

#### Užklausos pavyzdys

`POST  http://localhost:5259/api/categories`

```
{
    "name" : "Pardavimui",
    "description" : "NT pardavimui"
}
```

### PUT /categories/{id}

Atnaujiną kategorijos duomenis su duotais parametrais, kurie buvo nurodyti užklausos metu, id kartu su URL, o kiti parametrai perduodami kartu su užklausos body, funkcija prieinama tik administratoriui.
#### Metodo URL

`http://localhost:5259/api/categories/{id}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Bad request  | 400   |
| Unauthorized | 401   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas             | Pavyzdys             |
| ----------- | ----------- | -------------------------| -------------------- |
| description | Taip        | Gyvūno tipas             | `NT pardavimui`      |

#### Užklausos pavyzdys

`PUT http://localhost:5259/api/categories/9`

```
{
    "description": "Nekilnojamas turtas"
}
```

#### Atsakymo pavyzdys

```
{
    "id": 9,
    "name": "Nuomai",
    "description": "Nekilnojamas turtas"
}
```

### DELETE /categories/{id}

Ištrina kategoriją su nurodytu id per URL, funkcija prieinama tik administratoriui

#### Metodo URL

`http://localhost:5259/api/categories/{id}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| No Content   | 204   |
| Unauthorized | 401   |
| Not found    | 404   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas      | Pavyzdys |
| ----------- | ----------- | ------------------| -------- |
| id          | Taip        | kategorijos id    | `9`      |

#### Užklausos pavyzdys

`DELETE http://localhost:5259/api/categories/9`

#### Atsakymo pavyzdys

```
Tuščias body su statuso kodu 204 No content
```

## Skelbimų API metodai

### GET /categories/{id}/ads

Gražina sąrašą visų skelbimų, priklausančių tai kategorijai

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |

#### Užklausos pavyzdys

`GET http://localhost:5259/api/categories/10/ads`

#### Atsakymo pavyzdys

```
[
    {
        "id": 2,
        "name": "Pardavimui",
        "description": "NT pardavimui"
    },
    {
        "id": 3,
        "name": "Nuomai",
        "description": "NT nuomai"
    },
]
```

### GET /categories/{id}/ads/{adId}

Gražina kategorijos skelbimą pagal id, kuris perduodamas per URL

#### Metodo URL

` http://localhost:5259/api/categories/{id}/ads/{adId}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Not found    | 404   |

#### Užklausos pavyzdys

`GET http://localhost:5259/api/categories/10/ads/3`

#### Atsakymo pavyzdys

```
    {
    "id": 3,
    "name": "Pardavimui",
    "description": "NT pardavimui"
}
```

### POST /categories/{id}/ads/

Sukuria skelbimą nurodytais parametrais

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| No Content   | 201   |
| Bad request  | 400   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas             | Pavyzdys             |
| ----------- | ----------- | -------------------------| -------------------- |
| name        | Taip        | Skelbimo pavadinimas     | `Butas`              |
| description | Taip        | Skelbimo aprašymas       | `parduodu butą`      |

#### Užklausos pavyzdys

`POST  http://localhost:5259/api/categories/10/ads`

```
{
    "name": "string",
    "description": "string"
}
```

### PUT /animals/{id}/visits/{visitId}

Atnaujiną skelbimo duomenis su duotais parametrais, kurie buvo nurodyti užklausos metu, id kartu su URL, o kiti parametrai perduodami kartu su užklausos body

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Bad request  | 400   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas             | Pavyzdys             |
| ----------- | ----------- | -------------------------| -------------------- |
| name        | Taip        | Skelbimo pavadinimas     | `Butas`              |
| description | Taip        | Skelbimo aprašymas       | `parduodu butąąąą`   |

#### Užklausos pavyzdys

`PUT http://localhost:5259/api/categories/10/ads/4`

```
{
    "name": "string",
    "description": "string"
}
```

#### Atsakymo pavyzdys

```
Tuščias body su statuso kodu (200 Success)
```

### DELETE /categories/{id}/ads/{adId}

Ištrina skelbimą su nurodytu id per URL

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| No Content   | 204   |
| Not found    | 404   |

#### Užklausos pavyzdys

`DELETE http://localhost:5259/api/categories/10/ads/4`

#### Atsakymo pavyzdys

```
Tuščias body su statuso kodu 204 No content
```

## Procedūru API metodai

### GET /categories/{id}/ads/{adId}/comments

Gražina sąrašą visų specifinio skelbimo komentarų

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}/comments`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |

#### Užklausos pavyzdys

`GET  http://localhost:5259/api/categories/10/ads/4/comments`

#### Atsakymo pavyzdys

```
[
    {
        "id": 1,
        "name": "Naudotojas",
        "message": "Parduosi pigiau?"
    }
    {
        "id": 2,
        "name": "Pardavejas",
        "message": "ne"
    }
]
```

### GET /categories/{id}/ads/{adId}/comments/{commentId}

Gražina skelbimo komentarą pagal id, kuris perduodamas per URL

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}/comments/{commentId}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Not found    | 404   |

#### Užklausos pavyzdys

`GET  http://localhost:5259/api/categories/10/ads/4/comments/1`

#### Atsakymo pavyzdys

```
    {
        "id": 1,
        "name": "Naudotojas",
        "message": "Parduosi pigiau?"
    }
```

### POST /categories/{id}/ads/{adId}/comments

Sukuria skelbimo žinutę nurodytais parametrais

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}/comments`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| No Content   | 201   |
| Bad request  | 400   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas           | Pavyzdys          |
| ----------- | ----------- | ---------------------- | ----------------- |
| name        | Taip        | Žinutės savininkas     | `Naudotojas`      |
| message     | Taip        | Žinutė                 | `Duodu 200`       |

#### Užklausos pavyzdys

`POST http://localhost:5259/api/categories/10/ads/4/comments`

```
{
    "name": "string",
    "message": "string",
}
```

### PUT /categories/{id}/ads/{adId}/comments/{commentId}

Atnaujiną žinutės duomenis su duotais parametrais, kurie buvo nurodyti užklausos metu, id kartu su URL, o kiti parametrai perduodami kartu su užklausos body

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}/comments/{commentId}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| OK           | 200   |
| Bad request  | 400   |

#### Parametrai

| Pavadinimas | Ar būtinas? | Apibūdinimas           | Pavyzdys          |
| ----------- | ----------- | ---------------------- | ----------------- |
| name        | Taip        | Žinutės savininkas     | `Naudotojas`      |
| message     | Taip        | Žinutė                 | `Duodu 200`       |

#### Užklausos pavyzdys

`PUT http://localhost:5259/api/categories/10/ads/4/comments/1`

```
{
    "name": "string",
    "message": "string",
}
```

#### Atsakymo pavyzdys

```
Tuščias body su statuso kodu (200 Success)
```

### DELETE /categories/{id}/ads/{adId}/comments/{commentId}

Ištrina žinutę su nurodytu id per URL

#### Metodo URL

`http://localhost:5259/api/categories/{id}/ads/{adId}/comments/{commentId}`

#### Atsakymų kodai

| Pavadinimas  | Kodas |
| ------------ | ----- |
| No Content   | 204   |
| Not found    | 404   |

#### Užklausos pavyzdys

`DELETE http://localhost:5259/api/categories/10/ads/4/comments/1`

#### Atsakymo pavyzdys

```
Tuščias body su statuso kodu 204 No content
```
