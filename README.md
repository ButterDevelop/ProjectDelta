# ProjectDelta

**ProjectDelta** is an automated solution designed to sell **Steam items** on a third-party marketplace **("Dota/CS Market")**. The program seamlessly integrates with Steam to manage and list items for sale while ensuring that sensitive account data is securely stored and transmitted. Using advanced encryption, robust HTTP handling, and marketplace API integration, **ProjectDelta** streamlines the process of converting in-game inventory into marketable assets.

---

## Screenshots

![Screenshot 1](/screenshots/screenshot1.png)
![Screenshot 2](/screenshots/screenshot2.png)
![Screenshot 3](/screenshots/screenshot3.png)

## Overview

**ProjectDelta** automates the selling process by:

- **Managing Steam Accounts:**  
  It loads and manages SteamGuard account files through a manifest system, with support for encryption/decryption of sensitive data.

- **Secure Data Handling:**  
  Sensitive information is encrypted using AES-256 with a key derived via PBKDF2, ensuring that your Steam account data remains secure.

- **Marketplace API Integration:**  
  The application communicates with external Market APIs (for example, for CS:GO or Dota 2) to add items for sale, test connectivity, retrieve inventory data, and update account status.

- **Steam Profile Management:**  
  It fetches and processes Steam Web Profile XML data, converting images (such as full avatar images) to Base64 for internal use.

- **Local Database Management:**  
  ProjectDelta maintains an encrypted local database that tracks playing, market, and buffer accounts, and even synchronizes this data with a remote server.

- **Robust HTTP Requests:**  
  Using the [xNet](https://github.com/csharp-leaf/Leaf.xNet) library, the system handles HTTP requests with configurable retries, timeouts, and SSL certificate validation.

---

## Key Features

- **Automated Item Listing:**  
  Automatically lists Steam items on the Market with dynamically calculated pricing using configurable currency multipliers.

- **Manifest-Based Account Management:**  
  Uses a manifest file to track account files (*.maFile) along with encryption parameters (salt and IV) and Steam IDs.

- **Advanced Encryption:**  
  Encrypts/decrypts account data with AES-256 and PBKDF2 key derivation (with 50,000 iterations) to ensure data security.

- **Marketplace API Controls:**  
  Supports key operations such as adding items to sale, testing API connectivity, retrieving inventories, and pinging the server.

- **Steam Web Profile Parsing:**  
  Retrieves and parses Steam profile XML data, updates profile details, and converts images to Base64 strings.

- **Database Sync and Persistence:**  
  Periodically saves the current state of accounts and profiles in an encrypted JSON database, with options for server synchronization.

- **Custom HTTP Request Handling:**  
  Makes use of [xNet](https://github.com/csharp-leaf/Leaf.xNet) for robust HTTP communications with support for random User-Agent selection and SSL certificate validation.

---

## Technologies Used

- **C# and .NET:**  
  The entire project is developed in C#, leveraging object-oriented programming and .NET libraries for networking and cryptography.

- **Newtonsoft.Json:**  
  Utilized for JSON serialization and deserialization across manifests, API responses, and database models.

- **SteamAuth:**  
  A library for managing SteamGuardAccount objects and handling Steam authentication processes.

- **xNet:**  
  An HTTP request library that simplifies sending GET/POST requests with custom headers, timeouts, and certificate validation callbacks.

- **System.Security.Cryptography:**  
  Implements robust encryption using AES-256 in combination with PBKDF2 (RFC2898) for key derivation, along with secure random salt and IV generation.

- **XML Serialization:**  
  Uses `XmlSerializer` to deserialize Steam profile XML data into usable objects.

- **Multithreading:**  
  Employs threads to periodically save database data and handle asynchronous HTTP requests.

- **Custom Tools:**  
  Classes such as `FileEncryptor` and (presumably) `AesGcm256` encapsulate encryption/decryption logic, while helper classes manage API calls and data persistence.

---

## Project Structure

A simplified view of the project's folder structure:

```
ProjectDelta/
├── Controllers/
│ ├── ManifestSDAController.cs     # Handles manifest loading/saving, encryption/decryption of .maFile files
│ ├── MarketAPIController.cs       # Interacts with Market APIs (add-to-sale, test, inventory, etc.)
│ ├── SteamWebProfileController.cs # Retrieves and processes Steam web profile XML data
│ ├── HTTPRequestController.cs     # Sends HTTP requests using xNet
│ └── DBController.cs              # Manages saving/loading of encrypted local database data
├── Models/
│ ├── MarketItem.cs                # Model for items from the Market
│ └── DatabaseModel.cs             # Model for the local database schema
├── Tools/
│ └── FileEncryptor.cs             # Provides file encryption/decryption methods using AES-256 and PBKDF2
├── Properties/
│ └── Settings.settings            # Application settings (e.g., paths for manifest files, encryption keys, etc.)
├── ConstantsController.cs         # Contains constant values and configuration keys
├── Program.cs                     # Main entry point for the application
└── [Other utility and helper files]
```

---

## Configuration & Setup

Before running ProjectDelta, ensure that you:

1. **Configure Paths:**  
   Set the directory paths for manifest files and the local database in the application settings.

2. **Generate Encryption Keys:**  
   Use the provided methods (e.g., `CreateKeys()`) to generate a secure encryption key and initialization vector (IV) for data encryption.

3. **Set API Keys:**  
   Provide the required API keys for the Market API in the configuration.

4. **Initialize HTTP Settings:**  
   The application will initialize a pool of random User-Agent strings for its HTTP requests. No further configuration is typically necessary.

5. **(Optional) Sync Database:**  
   Configure server endpoints if you wish to synchronize the local database with a remote server.

*(Detailed setup instructions and configuration examples are available in the project documentation.)*

---

## Usage

ProjectDelta runs as a standalone application that:

- Loads and decrypts SteamGuard account files using a manifest.
- Automatically verifies account credentials with Steam.
- Uses the `MarketAPIController` to list items for sale on the Market.
- Periodically saves and synchronizes account and profile data in an encrypted local database.
- Provides utility methods for testing connectivity and updating account status on the marketplace.

---

## Contributing

Contributions and suggestions are welcome! If you find any issues or have ideas for improvement, please open an issue or submit a pull request. Ensure that your changes follow the project's coding guidelines and that you test new functionality thoroughly.

---

## License

[MIT License](LICENSE)

---

ProjectDelta is designed to simplify and automate the process of selling Steam items on external markets securely and efficiently. **Enjoy using ProjectDelta, and happy selling!**
