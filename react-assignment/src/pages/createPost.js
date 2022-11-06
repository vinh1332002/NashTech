import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../components/css/button.css";

function CreatePost() {
  const [person, SetPerson] = useState({
    firstName: "",
    lastName: "",
    gender: "",
    dateOfBirth: "",
    birthPlace: "",
  });

  const navigate = useNavigate();

  const handleChange = (evt) => {
    SetPerson({
      ...person,
      [evt.target.name]: evt.target.value,
    });
  };

  const handleBackToList = () => {
    navigate(`/post`);
  };

  const handleOnSubmit = (evt) => {
    evt.preventDefault();
    axios({
      method: "post",
      url: "https://localhost:7228/Task/list-adding",
      data: {
        firstName: person.firstName,
        lastName: person.lastName,
        gender: person.gender,
        dateOfBirth: person.dateOfBirth,
        birthPlace: person.birthPlace,
      },
    })
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });

    SetPerson({
      firstName: "",
      lastName: "",
      gender: "",
      dateOfBirth: "",
      birthPlace: "",
    });
    handleBackToList();
  };

  return (
    <div>
      <h1>CreatePost page</h1>
      <form onSubmit={handleOnSubmit}>
        <div>
          <label>
            First Name:
            <input
              type="text"
              placeholder="Enter person first name"
              onChange={handleChange}
              value={person.firstName}
              name="firstName"
              required
            />
          </label>
        </div>
        <div>
          <label>
            Last Name:
            <input
              type="text"
              placeholder="Enter person last name"
              onChange={handleChange}
              value={person.lastName}
              name="lastName"
              required
            />
          </label>
        </div>
        <div>
          <label>
            Gender:
            <select
              defaultValue="default"
              name="gender"
              onChange={handleChange}
              required
            >
              <option value="default">Choose a gender</option>
              <option value={person.gender + "Male"}>Male</option>
              <option value={person.gender + "Female"}>Female</option>
              <option value={person.gender + "Other"}>Other</option>
            </select>
          </label>
        </div>
        <div>
          <label>
            Date Of Birth:
            <input
              type="datetime-local"
              placeholder="Enter person date of birth"
              onChange={handleChange}
              value={person.dateOfBirth}
              name="dateOfBirth"
              required
            />
          </label>
        </div>
        <div>
          <label>
            BirthPlace:
            <input
              type="text"
              placeholder="Enter person birth place"
              onChange={handleChange}
              value={person.birthPlace}
              name="birthPlace"
              required
            />
          </label>
        </div>
        <div>
          <button class="submitButton" variant="primary" type="submit">
            Submit
          </button>
          <button class="backButton" onClick={handleBackToList} variant="secondary" type="reset">
            Back to Post Page
          </button>
        </div>
      </form>
    </div>
  );
}

export default CreatePost;
