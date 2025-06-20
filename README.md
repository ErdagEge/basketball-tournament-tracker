# Basketball Tournament Tracker

The **Basketball Tournament Tracker** is a web application built with .NET MVC using a NoSQL database. It is designed to streamline the organization and management of basketball tournaments by enabling easy tournament creation, team and player management, and real-time updates to tournament tables.

## Planned Features

- **Tournament Creation:** Easily set up new tournaments with customizable parameters.
- **Team Management:** Add, edit, and manage teams participating in the tournament.
- **Player Profiles:** Create and update player profiles, including statistics and performance metrics.
- **Tournament Table:** Automatically generate and update tournament tables to reflect game results.
- **Data Storage:** Efficiently store and retrieve all tournament-related data using a NoSQL database.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/ErdagEge/basketball-tournament-tracker.git
    ```

2. Navigate into the project directory and restore dependencies:
    ```bash
    cd basketball-tournament-tracker
    dotnet restore
    ```

3. Build the project:
    ```bash
    dotnet build
    ```

4. Ensure MongoDB is running on `mongodb://localhost:27017/` (the default connection string).

5. Run the application:
    ```bash
    dotnet run
    ```

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

1. Fork the repository.

2. Create a new branch:
    ```bash
    git checkout -b feature/your-feature-name
    ```
3. Commit your changes:
    ```bash
    git commit -m 'Add some feature'
    ```
4. Push to the branch:
    ```bash
    git push origin feature/your-feature-name
    ```
5. Create a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.txt) file for details.
