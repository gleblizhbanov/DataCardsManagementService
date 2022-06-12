# Data cards management service

Web app provides HTTP REST API (ASP.NET Core 3.0), deployed as a windows service.
Client WPF app uses .NET Framework 4.7

### Server part capabilites
- Load data cards from JSON file (stored on server).
- Save added and edited card to file (stored on server).
- Processing GUI CRUD requests for data cards.

### Client part capabities
- Show list of all data cards with images in Home page GUI.
- Support for CRUD operations for data cards.
- Supports JPG format for images.
