# UniquePlanners.API

The Unique Planners application is a comprehensive solution developed to serve a local shop specializing in selling a wide range of planners, including daily, weekly, wedding, fitness, and student planners.

The application consists of a user-friendly web app that provides information about the Unique Planners shop. It showcases the available planner types and displays various designs for each type, allowing customers to explore and choose from a diverse selection. Additionally, the web app offers valuable details on purchasing procedures and directions to the physical shop location.

To facilitate seamless management, the application also includes an admin panel. The admin panel empowers the administrator to effortlessly add new types of planners and their corresponding designs, ensuring the shop can regularly update its offerings to meet customer demands.

With its clean architecture and the powerful combination of .NET Core for the backend, Angular for the web app, and Docker for containerization, the Unique Planners application provides an intuitive and efficient platform for both customers and the shop's administrative team.

## Docker
### Steps
1. Open a terminal or command prompt.
2. Navigate to the directory where your docker-compose.yml file is located.
3. Run the following command to start the containers:
```
  docker-compose up -d
```
4. Verify the app is running:
- Check the terminal output for any errors during the container startup process.
- If everything is successful, you should see the containers starting up.
- Test your app by accessing it through the specified ports or URLs.
5. To stop the running containers, use the following command:
```
docker-compose down
```

## Swagger login
### Steps
1. Obtain JWT Token:
- Send a post request to the insert endpoint to create a new user.
- Send a POST request to the login endpoint with your credentials (username and password). 
- On successful authentication, you will receive a JWT token in the response.
2. Configure Swagger UI:
- Locate the authentication section in the Swagger UI.
- Click on the "Authorize" button
- In the "Value" field, enter Bearer JWT Token, replacing JWT Token with the actual JWT token obtained in Step 1.
  Click on the "Authorize" button to save the changes.
3. Test API Endpoints:
- Now, all API requests made through Swagger UI will include the JWT token in the Authorization header with the value Bearer JWT Token.
- You can test the API endpoints by providing the required input and executing the requests.
