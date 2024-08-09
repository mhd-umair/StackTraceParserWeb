# Stack Trace Parser Web Application

## Overview

The Stack Trace Parser Web Application is an ASP.NET Core MVC application designed to parse .NET stack traces and display them in a user-friendly, readable HTML format. The application supports parsing stack traces with different levels of complexity, including method calls, file paths, line numbers, and exceptions.

## Features

- **Stack Trace Parsing**: Converts raw .NET stack traces into a formatted HTML view for easier reading and debugging.
- **Exception Handling**: Displays the exception type and message along with the stack trace.
- **Validation**: Includes both client-side and server-side validation to ensure that the stack trace input is required.
- **Bootstrap Integration**: Utilizes Bootstrap for styling, including form validation feedback and user interface components.
- **Unit Tests**: Includes unit tests to validate the core functionality of the stack trace parser.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Code Structure](#code-structure)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) 2022 or later with .NET 8 support, or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**:

    ```bash
    git clone https://github.com/mhd-umair/StackTraceParserWeb.git
    cd StackTraceParserWeb
    ```

2. **Restore NuGet packages**:

    ```bash
    dotnet restore
    ```

3. **Build the project**:

    ```bash
    dotnet build
    ```

4. **Run the application**:

    ```bash
    dotnet run
    ```


## Usage

1. **Paste your stack trace** into the provided textarea on the home page.
2. **Click "Parse Stack Trace"** to format the stack trace and view it in a more readable format.
3. **Review the output**, which includes the parsed stack trace with highlighted method names, file paths, and line numbers, as well as any exception details.

## Running Tests

The application includes unit tests for the stack trace parser service. To run the tests:

1. **Navigate to the test project**:

    ```bash
    cd StackTraceParserWeb.Tests
    ```

2. **Run the tests**:

    ```bash
    dotnet test
    ```

   The test results will be displayed in the terminal or the Test Explorer in Visual Studio.

## Code Structure

- **Controllers**
  - `HomeController.cs`: Handles the main web requests and actions, including rendering the index page and processing the stack trace.

- **Models**
  - `StackTraceEntry.cs`: Represents a parsed entry from the stack trace, including method name, file path, and line number.

- **Services**
  - `StackTraceParserService.cs`: Contains the core logic for parsing stack traces into `StackTraceEntry` objects and formatting them into HTML.

- **Views**
  - **Home/Index.cshtml**: The main view where users can input their stack trace and view the formatted output.
  - **Shared/_Layout.cshtml**: The layout file that includes Bootstrap and shared UI components.

- **wwwroot**
  - **css/site.css**: Custom styles for the application, including Bootstrap overrides and specific styling for the parsed stack trace.
  - **js/site.js**: Handles client-side validation and form submission.

- **Tests**
  - **StackTraceParserServiceTests.cs**: Unit tests for the `StackTraceParserService` to ensure the parser works as expected.

## Contributing

Contributions are welcome! Please fork this repository and submit pull requests with your changes.

1. **Fork the repository**.
2. **Create a new branch** for your feature or bugfix.
3. **Commit your changes** and push them to your fork.
4. **Submit a pull request**.

Please make sure to write tests for your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
