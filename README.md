# FileAnalyzerWinForm

**FileAnalyzerWinForm** is a modular **Windows Forms** desktop application built with C# and **.NET Framework 4.8**. It extracts text from different file formats and performs word-frequency and punctuation analysis.

The application includes user registration and sign-in, asynchronous analysis, JSON export of analysis results, exception handling, and file-based logging.

## Features

### User management

- **Sign In** and **Create Account** panels within the same form.
- Validation for required fields, password length, and duplicate usernames.
- Password storage using **PBKDF2-HMAC-SHA256** with a random salt and iteration count, rather than plaintext passwords.
- Persistent user records in `users.txt`, without requiring a database server.
- Navigation to the file analysis window (`MainForm`) after a successful sign-in.

### Supported file formats

- `.txt` — plain-text files
- `.docx` — Word documents
- `.pdf` — text-based PDF documents
- `.xlsx` — text cells from Excel workbooks

Each reader implements the `IFileReader` interface. `FileReaderFactory` selects the appropriate reader by extension, making the design extensible.

### Word analysis

- Counts **total words** (excluding numbers and stop words).
- Counts **distinct words**.
- Lists **repeated words**, their frequencies, and sorts them in descending order.
- Normalizes letter case.
- Excludes numbers and configured conjunctions/common stop words (`StopWords`) from word analysis.

### Punctuation analysis

- Counts punctuation marks found in the extracted text.
- Displays the frequency of each punctuation symbol.

### UI, exception handling, and logging

- File-type selection, an **Upload** button that becomes available after selection, and a file picker.
- **`async/await` and `Task.Run`** for analysis, with a ProgressBar indicating activity.
- An **Export JSON** button, enabled after a successful analysis, that saves the results (file name and path, export time, total and distinct word counts, repeated words, and punctuation counts) as a `.json` file.
- User-friendly errors for corrupt or unreadable files.
- Centralized exception handling: the whole project uses a single `try/catch`, located in `ExceptionHandler`.
- Library-specific errors from the file readers are wrapped in `FileReadException`, so they share one consistent message.
- `INFO` entries for successful file analysis, and `ERROR` entries for analysis and authentication system failures.
- Technical exception details, including the original cause (inner exception), are kept in log files rather than displayed directly to users.
- System exception messages are always logged in English, whatever the Windows display language.

> **Note:** The reference README mentions **listing user accounts** and **exporting results to Excel**. These are **not implemented features** in the current project. `.xlsx` support means **reading Excel files**, not exporting results; analysis results can currently be exported as **JSON** only.

## Architecture

The solution separates responsibilities across the following components:

| Component | Responsibility |
| --- | --- |
| **Analysis** | `TextAnalyzer`, `PunctuationAnalyzer`, and `StopWords` for text analysis. |
| **Authentication** | `AuthService` for registration/sign-in rules; `PasswordHasher` for password handling; `IUserRepository` and `TxtUserRepository` for user persistence. |
| **Models** | `User`, `AuthResult`, and `AnalysisResult` data models. |
| **Services** | The `IFileReader` contract, `FileReaderFactory`, and file-format-specific readers; the `IResultExporter` contract and `JsonResultExporter` for exporting results. || **Logging** | The `ILogger` abstraction and `FileLogger` implementation. |
| **Exceptions** | `ExceptionHandler` (the single, project-wide `try/catch`) and custom exceptions for file-processing scenarios. |
| **View** | The `LoginForm` and `MainForm` user interfaces. |
| **Program.cs** | Application entry point and dependency wiring (*Composition Root*). |

**Application flow:**

```text
Program.cs → LoginForm → AuthService
                            ├── PasswordHasher
                            ├── IUserRepository → TxtUserRepository → users.txt
                            └── ILogger → FileLogger → Logs/
                ↓ successful sign-in
              MainForm → FileReaderFactory → IFileReader
                                             ↓
                               TextAnalyzer / PunctuationAnalyzer
                                             ↓
                                        AnalysisResult
                                        ↓ Export JSON
                               IResultExporter → JsonResultExporter → .json
```

`AuthService` depends on the `IUserRepository` abstraction rather than a specific storage implementation, and uses `ILogger` for logging. This supports **Dependency Injection**, a **Repository-based design**, the **Factory Pattern**, and **Separation of Concerns**.

Exception handling is centralized in `ExceptionHandler`. Each layer passes its work and its own `onError` callback to the handler, so the *catching* mechanism is shared while each layer still decides what an error *means*: `AuthService` maps errors to an `AuthResult`, `MainForm` logs them and shows a message, `PasswordHasher` returns `false`, and `FileLogger` ignores write failures so logging never crashes the application.

## Technologies

- **C#**
- **.NET Framework 4.8**
- **Windows Forms (WinForms)**
- **Asynchronous programming:** `async/await`, `Task.Run`
- **File I/O:** `System.IO`
- **Password hashing:** PBKDF2-HMAC-SHA256 (`Rfc2898DeriveBytes`)
- **Git / GitHub**

**NuGet libraries used for file reading:**

- [DocumentFormat.OpenXml (Open XML SDK)](https://www.nuget.org/packages/DocumentFormat.OpenXml) — DOCX documents
- [PdfPig](https://www.nuget.org/packages/PdfPig) — PDF documents
- [ClosedXML](https://www.nuget.org/packages/ClosedXML) — XLSX workbooks
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) — JSON export of analysis results

> Refer to the project's `.csproj` / NuGet references for exact package versions and the DOCX reader's installed dependency.

## Requirements and installation

- **Windows**
- **Visual Studio 2022 or later** (developed using Visual Studio 2026)
- **.NET Framework 4.8 Developer Pack / targeting pack**

1. Clone the repository:

   ```bash
   git clone https://github.com/ahmetkamac16/FileAnalyzerWinForm.git
   ```

2. Open the project in Visual Studio (using its `.sln` solution file or `FileAnalyzerWinForm.csproj`).
3. Restore missing dependencies using **Restore NuGet Packages**.
4. Run **Build Solution** (`Ctrl + Shift + B`).
5. Start the application with **Start** or `F5`.

## Usage

1. On the initial screen, select **Create Account** to register a username and password.
2. Use **Sign In** to authenticate with an existing account.
3. In `MainForm`, select a supported format (`.txt`, `.docx`, `.pdf`, or `.xlsx`).
4. Click **Upload** and choose a file.
5. Review total and distinct word counts, repeated-word frequencies, and punctuation statistics.
6. Optionally, click **Export JSON** to save the results as a `.json` file.

## User data and logs

In **Debug mode**, paths are based on the executable's base directory:

```text
bin/Debug/
├── Logs/
│   └── log_YYYY-MM-DD.txt
└── Users/
    └── users.txt
```

- `Users/users.txt` stores usernames, PBKDF2 iteration counts, salts, and password hashes; **plaintext passwords are not stored**.
- `Logs/log_YYYY-MM-DD.txt` stores dated `INFO` and `ERROR` entries.
- These folders and files are created by the application when necessary.
- **Release mode** uses `bin/Release/`. The `.gitignore` excludes `bin/`, so actual user records and logs are not committed to GitHub.
- Successful sign-ins and registrations do not generate separate `INFO` entries.

> **Security limitation:** The TXT-based local user repository is intended for learning and demonstrations. Because a local user can alter the file, this is not a substitute for server-side authentication in production systems.

## Project structure

```text
FileAnalyzerWinForm/
├── Analysis/
│   ├── PunctuationAnalyzer.cs
│   ├── StopWords.cs
│   └── TextAnalyzer.cs
├── Authentication/
│   ├── AuthService.cs
│   ├── IUserRepository.cs
│   ├── PasswordHasher.cs
│   └── TxtUserRepository.cs
├── Exceptions/
│   ├── ExceptionHandler.cs
│   ├── FileReadException.cs
│   └── UnsupportedFileTypeException.cs
├── Logging/
│   ├── FileLogger.cs
│   └── ILogger.cs
├── Models/
│   ├── AnalysisResult.cs
│   ├── AuthResult.cs
│   └── User.cs
├── Services/
│   ├── DocxFileReader.cs
│   ├── FileReaderFactory.cs
│   ├── IFileReader.cs
│   ├── IResultExporter.cs
│   ├── JsonResultExporter.cs
│   ├── PdfFileReader.cs
│   ├── TxtFileReader.cs
│   └── XlsxFileReader.cs
├── View/
│   ├── LoginForm.cs
│   ├── LoginForm.Designer.cs
│   ├── LoginForm.resx
│   ├── MainForm.cs
│   ├── MainForm.Designer.cs
│   └── MainForm.resx
├── Program.cs
├── FileAnalyzerWinForm.csproj
└── .gitignore
```

> `bin/` and `obj/` are generated build folders and are intentionally omitted from the source tree above.
