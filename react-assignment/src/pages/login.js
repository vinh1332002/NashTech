import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../hooks/authContext";
import React, { useState, useMemo } from "react";
import InputModel from "../components/forms/input";
import "../components/css/button.css";

const initialValues = {
  email: "",
  password: "",
  read: false,
};

const required = (value) => {
  if (value === null || value === undefined || value === "") {
    return "this field is required";
  }
  return "";
};

const minLength = (value, length) => {
  if (value.length < length) return `At least ${length} characters`;
  return "";
};

const pattern = (value, regex, message) => {
  if (!regex.test(value)) return message;
  return null;
};

const getEmailError = (value) => {
  return (
    required(value) ||
    pattern(
      value,
      /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/,
      "Invalid email format!"
    )
  );
};

const getPasswordError = (value) => {
  return required(value) || minLength(value, 8);
};

function Login() {
  let navigate = useNavigate();
  const { setIsAuthenticated } = useAuthContext();

  const login = () => {
    localStorage.setItem("token", "124124");
    setIsAuthenticated(true);
    navigate("/");
  };

  const [values, setValues] = useState(initialValues);

  const emailError = useMemo(() => {
    return getEmailError(values.email);
  }, [values.email]);

  const passwordError = useMemo(() => {
    return getPasswordError(values.password);
  }, [values.password]);

  const isFormValid = !emailError && !passwordError;

  const handleOnChange = (event) => {
    const newValues = {
      ...values,
      [event.target.name]:
        event.target.name === "read"
          ? event.target.checked
          : event.target.value,
    };
    setValues(newValues);
  };

  return (
    <div>
      <h1>Login page</h1>
      <div>
        <form>
          <InputModel
            value={values.email}
            onChange={handleOnChange}
            name="email"
            label="Email:"
            error={emailError}
          />

          <InputModel
            value={values.password}
            onChange={handleOnChange}
            name="password"
            label="Password:"
            error={passwordError}
          />

          <br />

          <div>
            <button
              class="submitButton"
              type="button"
              disabled={!isFormValid}
              onClick={login}
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default Login;
