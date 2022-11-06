import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import "../components/css/button.css";

function UpdatePost() {
  const navigate = useNavigate();

  const handleBackToList = () => {
    navigate(`/post`);
  };

  const { id } = useParams();
  const [data, setData] = useState([]);

  const [person, setPerson] = useState({
    firstName: "",
    lastName: "",
    gender: "",
    dateOfBirth: "",
    birthPlace: "",
  });

  useEffect(() => {
    axios({
      method: "GET",
      url: `https://localhost:7228/Task/one-list?index=${id}`,
      data: null,
    })
      .then((response) => {
        console.log(response.data);
        setData(response.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  const handleOnSubmit = (evt) => {
    evt.preventDefault();
    axios({
      method: "put",
      url: `https://localhost:7228/Task/list-update?index=${data.uniqueId}`,
      data: {
        uniqueId: person.uniqueId,
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
    handleBackToList();
  };

  const handleChange = (event) => {
    setPerson({
      ...person,
      [event.target.name]: event.target.value,
    });
  };

  return (
    <div>
      <h1>Update person {person.firstName}:</h1>
      <form onSubmit={handleOnSubmit}>
        <div>
          <label>
            First Name:
            <input
              type="text"
              onChange={handleChange}
              defaultValue={person.firstName}
              name="firstName"
              required
            ></input>
          </label>
        </div>
        <div>
          <label>
            Last Name:
            <input
              type="text"
              onChange={handleChange}
              defaultValue={person.lastName}
              name="lastName"
              required
            ></input>
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
              onChange={handleChange}
              defaultValue={person.dateOfBirth}
              type="datetime-local"
              name="dateOfBirth"
              required
            ></input>
          </label>
        </div>
        <div>
          <label>
            BirthPlace:
            <input
              type="text"
              onChange={handleChange}
              defaultValue={person.birthPlace}
              name="birthPlace"
              required
            ></input>
          </label>
        </div>
        <div>
          <button class="submitButton" value={data.uniqueId} type="submit">
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

export default UpdatePost;
