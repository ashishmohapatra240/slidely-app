# Slidely Windows App

## Overview

This project is a Windows Desktop Application, It allows users to create, view, and edit form submissions. The application is built using Visual Basic in Visual Studio and interacts with a backend server to store and retrieve form data.

## Features

- **View Submissions**: View submitted forms with navigation to go through entries one by one.
- **Create New Submission**: Create a new form submission with fields for Name, Email, Phone Number, GitHub repo link, and a stopwatch.
- **Edit Submission**: Edit an existing form submission.
- **Delete Submission**: Delete an existing form submission.
- **Search by Email**: Search for a submission by email address.
- **Check Server Status**: Check if the backend server is running.
- **Keyboard Shortcuts**: Use keyboard shortcuts for quicker navigation and actions.

## Backend API

The backend server provides the following endpoints:

- `GET /ping`: Check server status.
- `POST /submit`: Submit a new form entry.
- `GET /read`: Retrieve a specific form entry by index.
- `DELETE /delete`: Delete a specific form entry by index.
- `PUT /edit`: Edit a specific form entry by index.
- `GET /search`: Search form entries by email.

## Prerequisites

- Visual Studio with Visual Basic support
- Backend server running on `http://localhost:3000`

## Setup and Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/ashishmohapatra240/slidely-app.git
    cd slidely-app
    ```
    
2. **Backend Setup**:
    - Ensure your backend server is running on `http://localhost:3000`.
    - Follow the backend setup instructions.

3. **Build and run the project**:
    - Build the solution by clicking on `Build > Build Solution`.
    - Run the application by clicking on `Debug > Start Debugging`.


![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/7d66d4c5-0d74-4bbb-bd30-b27ea3d7c173)

### View Submissions

1. Open the application.
2. Click on the `View Submissions` button or use the shortcut `Ctrl + V`.
3. Navigate through the submissions using the `Previous` (Ctrl + P) and `Next` (Ctrl + N) buttons.

![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/0a8fa4b3-bc69-41fe-b049-17347f84a578)


### Create New Submission

1. Open the application.
2. Click on the `Create New Submission` button or use the shortcut `Ctrl + N`.
3. Fill in the details: Name, Email, Phone Number, GitHub Link.
4. Use the `Toggle Stopwatch` button (Ctrl + T) to start/stop the stopwatch.
5. Click on the `Submit` button (Ctrl + S) to submit the form.

![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/c35b6f91-cd15-40ff-b50d-0347bde236de)


### Edit Submission

1. While viewing a submission, click on the `Edit` button (Ctrl + E).
2. The `FormEditSubmission` window will open with the current submission details.
3. Make the necessary changes and click on `Submit` to save the changes.

![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/964241ea-6e64-486b-8179-0181d83279d8)


### Delete Submission

1. While viewing a submission, click on the `Delete` button (Ctrl + D).
2. The submission will be deleted, and the first submission will be loaded.

![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/df8ea620-763c-4f2f-be73-9504017bb9a9)



### Check by Email

1. Navigate to the `Search by Email` feature.
2. Enter the email address of the submission you want to find in the provided text field.
3. Click on the `Search` button or use the shortcut `Ctrl + F`.
4. The application will display the submission details associated with the provided email address.

![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/6c97d894-46a9-496b-a14f-073571a89c70)

### Check Server Status

1. Click on the `Check Server` button.
2. The application will send a request to the server to check its status.
3. A message box will display the server status (e.g., "Server is running" or "Server is not reachable").

![image](https://github.com/ashishmohapatra240/slidely-app/assets/78657461/c84f11b9-f70a-4c62-9b34-a670c5075ac5)





