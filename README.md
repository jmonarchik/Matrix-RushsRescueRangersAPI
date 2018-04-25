# Matrix-RushsRescueRangersAPI
API for the Matrix-RushsRescueRangers app

**Backlog:**
1. ~~Get All Animals Action~~
2. ~~Get Animal Action~~
3. ~~Create Animal Action~~
4. ~~Delete Animal Action~~
5. ~~Update Animal Action~~
6. Adoption

**Show All Animals**
----
* **URL**
/api/animals

* **Method:**
    `GET`

* **Data Params**
    None

* **Success Response**

* **Code:** 200 <br/>
  **Content:**
`[
  {
    "id": 1,
    "name": "Fluffy",
    "species": "Dog",
    "imageUrl": "https://i.imgur.com/eZwTsb6.jpg",
    "gender": "M",
    "description": "Quis nostrum exercitationem ullam corporis suscipit laboriosam cosmos shores.",
    "isAdopted": false,
    "shelterId": 0
  },
  {
    "id": 2,
    "name": "Pickles",
    "species": "Cat",
    "imageUrl": "https://i.imgur.com/zItMO7k.jpg",
    "gender": "M",
    "description": "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
    "isAdopted": false,
    "shelterId": 0
  },
  {
    "id": 5,
    "name": "Brenda",
    "species": "Dog",
    "imageUrl": "https://i.imgur.com/nTt8wvq.jpg",
    "gender": "F",
    "description": "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
    "isAdopted": true,
    "shelterId": 0
  },
  {
    "id": 6,
    "name": "Henry",
    "species": "dog",
    "imageUrl": "https://i.imgur.com/5V21pDS.jpg",
    "gender": "M",
    "description": "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
    "isAdopted": false,
    "shelterId": 0
  },
  {
    "id": 7,
    "name": "Cathy",
    "species": "Cat",
    "imageUrl": "https://i.imgur.com/zItMO7k.jpg",
    "gender": "M",
    "description": "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
    "isAdopted": false,
    "shelterId": 0
  },
  {
    "id": 2,
    "name": "Pickles",
    "species": "Cat",
    "imageUrl": "https://i.imgur.com/w6TFe5X.jpg",
    "gender": "M",
    "description": "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
    "isAdopted": true,
    "shelterId": 0
  }
]`

**Show Animal**
----
* **URL**
/api/animals/:id

* **Method:**
    `GET`

* **URL Params**
  **Required:**
  `id=[integer]`

* **Data Params**
    None

* **Success Response**

* **Code:** 200 <br/>
  **Content:** <br/>
`[
  {
    "id": 1,
    "name": "Fluffy",
    "species": "Dog",
    "imageUrl": "https://i.imgur.com/eZwTsb6.jpg",
    "gender": "M",
    "description": "Quis nostrum exercitationem ullam corporis suscipit laboriosam cosmos shores.",
    "isAdopted": false,
    "shelterId": 0
  }
]`

* **Error Response:**
* **Code:**204 NO CONTENT<br/>

=======================================================================

**Update Animal**
----
* **URL**
/api/animals/:id

* **Method:**
    `PUT`

* **URL Params**
  **Required:**
  `id=[integer]`

* **Data Params**
    Animal: <br/>
    `{
      "id": number,
      "name": string,
      "species": string,
      "imageUrl": string,
      "gender": string,
      "description": string,
      "isAdopted": boolean,
      "shelterId": number
    }`

* **Success Response**

* **Code:** 200 <br/>
  **Content:** <br/>
`[
  {
    "id": 1,
    "name": "Fluffy",
    "species": "Dog",
    "imageUrl": "https://i.imgur.com/eZwTsb6.jpg",
    "gender": "M",
    "description": "Quis nostrum exercitationem ullam corporis suscipit laboriosam cosmos shores.",
    "isAdopted": false,
    "shelterId": 0
  }
]`

* **Error Response:**
* **Code:**404 NOT FOUND<br/>

**Delete Animal**
----
* **URL**
/api/animals/:id

* **Method:**
    `PUT`

* **URL Params**
  **Required:**
  `id=[integer]`

* **Data Params**
    None

* **Success Response**

* **Code:** 204 NO CONTENT<br/>
  **Content:** <br/>
    None

* **Error Response:**
* **Code:**404 NOT FOUND<br/>
