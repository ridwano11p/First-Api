import React, { useState, useEffect } from "react";
import axios from "axios";
import { Card, CardBody, CardTitle, CardText } from "reactstrap";

function App() {
  // Initialize the state with an empty array
  const [data, setData] = useState([]);

  // Fetch the data from the api when the component mounts
  useEffect(() => {
    axios
      .get("https://localhost:7054/api/Brand")
      .then((response) => {
        // Set the state with the fetched data
        setData(response.data);
      })
      .catch((error) => {
        // Handle the error
        console.error(error);
      });
  }, []);

  // Define a function to handle form submission
  const handleSubmit = (event) => {
    // Prevent the default browser behavior
    event.preventDefault();
    // Get the form data from the event object
    const formData = new FormData(event.target);
    // Convert the form data to an object
    const dataObject = Object.fromEntries(formData.entries());
    // Send a post request with axios
    axios
      .post("https://localhost:7054/api/Brand", dataObject)
      .then((response) => {
        // Handle the response
        console.log(response);
      })
      .catch((error) => {
        // Handle the error
        console.error(error);
      });
  };

  // Render the data as cards using reactstrap
  return (
    <div className="App">
      {data.map((item) => (
        <Card key={item.id} style={{ width: "300px", margin: "10px" }}>
          <CardBody>
            <CardTitle tag="h5">{item.name}</CardTitle>
            <CardText>{item.description}</CardText>
            <CardText>Price: {item.price}</CardText>
            <CardText>Unit: {item.unit}</CardText>
          </CardBody>
        </Card>
      ))}
      // Render a form to add a new item
      <form onSubmit={handleSubmit}>
        <label htmlFor="name">Name:</label>
        <input type="text" id="name" name="name" required />
        <label htmlFor="description">Description:</label>
        <input type="text" id="description" name="description" required />
        <label htmlFor="price">Price:</label>
        <input type="number" id="price" name="price" required />
        <label htmlFor="unit">Unit:</label>
        <input type="text" id="unit" name="unit" required />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default App;
