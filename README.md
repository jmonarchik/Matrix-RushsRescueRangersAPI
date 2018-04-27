# Matrix-RushsRescueRangersAPI
API for the Matrix-RushsRescueRangers app

**Backlog:**
1. ~~Get All Animals Action~~
2. ~~Get Animal Action~~
3. ~~Create Animal Action~~
4. ~~Delete Animal Action~~
5. ~~Update Animal Action~~
6. ~~Adoption~~
	* Create Adoption
	* Create Adopter
	* Update Animal with Adoption Id
7. Incorporate a Database

**Swagger Info**
* **UI:**
	`"/"`

* **JSON:**
	`"/swagger/v1/swagger.json"`

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
```
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
```

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
```
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
```

* **Error Response:**
* **Code:** 204 NO CONTENT<br/>

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
    ```
    {
      "id": number,
      "name": string,
      "species": string,
      "imageUrl": string,
      "gender": string,
      "description": string,
      "isAdopted": boolean,
      "shelterId": number
    }
    ```

* **Success Response**

* **Code:** 200 <br/>
  **Content:** <br/>
```
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
```

* **Error Response:**
* **Code:** 404 NOT FOUND<br/>

**Delete Animal**
----
* **URL**
`"/api/animals/:id"`

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
* **Code:** 404 NOT FOUND<br/>

**Create Adoption**
---
* **URL**
`"/api/adoptions"`

* **Method:**
	'POST'
* **URL PARAMS**
	None
* **Data Params**
	AdoptionBody: <br/>
	```
	{
		{
		  "animal": {
			"id": 4,
			"name": "string",
			"species": "string",
			"imageUrl": "string",
			"gender": "string",
			"description": "string",
			"isAdopted": true,
			"adoptionId": 0,
			"shelterId": 0
		  },
		  "adopter": {
			"id": 0,
			"firstName": "Bradford",
			"lastName": "Stanley",
			"address": "string",
			"city": "string",
			"state": "string",
			"zipcode": 0,
			"phoneNo": "string"
		  }
		}
	}
	```
* **Success Response**

* **Code:** 200 <br/>

* **Error Response:**
* **Code:** 404 NOT FOUND<br/>
* **Code:** 404 BAD REQUEST<br/>

* **Stuff I found helpful**
[Building Your First API with ASP.NET Core](https://app.pluralsight.com/library/courses/asp-dotnet-core-api-building-first/table-of-contents)
[Make Ctrl + D Work in Visual Studio like it does in Sublime](https://marketplace.visualstudio.com/items?itemName=thomaswelen.SelectNextOccurrence)
[Setting up Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml)
[Enabling CORs](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api)
*Note - We don't need a package installation because the CORs package is included in AspNetCore.all





