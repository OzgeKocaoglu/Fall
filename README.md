<div align="center"> 

<img src="https://github.com/OzgeKocaoglu/Fall/blob/master/Fall/docs/fall%20banner.png" alt="logo" width="400" height="auto" />

<h1>Prometheus</h1>
  <p>
   :balloon: Fall is a game project developed in Unity using C#. Player data is stored in a MongoDB database and accessed via a REST API built with JavaScript and Node.js. The project utilizes Zenject for dependency injection and UniRx for reactive programming.
  </p>
</div>

<br />

<!-- Table of Contents -->
# :notebook_with_decorative_cover: Table of Contents

- [Technologies Used](#technologies-used)
- [Features](#features)
- [Setup](#setup)
   * [Requirements](#requirements)
   * [Steps](#steps)
- [Run](#running-the-Project)
- [Gameplay Video](#gameplay-video)
- [License](#license)


## Technologies Used
- **Unity & C#** - Game development
- **JavaScript & Node.js** - For API development
- **MongoDB** - Database
- **Zenject** - Dependency Injection
- **UniRx** - Reactive programming
- **Photoshop** - Asset editing

## Features

- **Unity & C#**: The game is built in Unity using C#.
- **REST API**: Player data is accessed through an API created with JavaScript and Node.js.
- **Database**: Player data is stored in MongoDB.
- **Dependency Management**: Zenject is used to manage class relationships within the game.
- **Reactive Programming**: UniRx is used instead of .NET Reactive Extensions.
- **Asset Editing**: In-game assets were sourced from DeviantArt and customized in Photoshop.

## Future Improvements

- Containerization of the Node.js API using Docker and deployment on Kubernetes.

## Setup

### Requirements

- [Node.js](https://nodejs.org/)
- [MongoDB](https://www.mongodb.com/)
- [Unity](https://unity.com/) - The version used for development
- [Docker](https://www.docker.com/) (for future Kubernetes deployment)

### Steps

1. **Database Setup**: Start MongoDB and create the necessary database.

2. **Run the API**:
   ```bash
   cd api
   npm install
   npm install express
   npm install bcrypt
   node server.js

   
## Running the Project

1. Open the Fall project in Unity.
2. Configure MongoDB and API URLs in the project settings.
3. Run the game in the Unity editor.

## Gameplay Video
https://www.youtube.com/watch?v=cegnxasAeMI&t=120s


## License
This project is licensed under the MIT License - see the LICENSE file for details.

