// This file contains the SignUpPage component for new user registration

// Import necessary hooks and components
import { useState } from "react";
import {
  Container,
  Paper,
  Typography,
  TextField,
  Button,
  Box,
} from "@mui/material";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

// Import our user registration function
import { registerUser } from "../data/mockUsers";

// Define and export the SignUpPage component
export function SignUpPage() {
  // State variables to store form input values
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  // State for error messages
  const [error, setError] = useState("");

  // Navigation function for redirecting after signup
  const navigate = useNavigate();
  // Get the login function from our authentication context
  const { login } = useAuth();

  // Handle form submission
  const handleSubmit = (e) => {
    // Prevent default form submission behavior
    e.preventDefault();
    // Clear any previous error messages
    setError("");

    // Validate that passwords match
    if (password !== confirmPassword) {
      setError("Passwords do not match");
      return;
    }

    // Create a user object with the form data
    const userData = {
      email,
      password,
      firstName,
      lastName,
    };

    // Register the new user using our mock registration function
    const result = registerUser(userData);

    // If registration was successful
    if (result.success) {
      // Log the user in with the newly created account
      login(email, password);
      // Redirect to the home page
      navigate("/");
    } else {
      // If registration failed, display the error
      setError(result.error);
    }
  };

  return (
    // Container with maximum width and top margin
    <Container
      maxWidth="sm"
      sx={{ mt: 8 }}
    >
      {/* Paper component provides a card-like surface */}
      <Paper sx={{ p: 4 }}>
        {/* Page title */}
        <Typography
          variant="h4"
          component="h1"
          gutterBottom
          align="center"
        >
          Sign Up
        </Typography>

        {/* Display error message if there is one */}
        {error && (
          <Typography
            color="error"
            align="center"
            sx={{ mb: 2 }}
          >
            {error}
          </Typography>
        )}

        {/* Registration form */}
        <Box
          component="form"
          onSubmit={handleSubmit}
        >
          {/* First Name input field */}
          <TextField
            fullWidth
            label="First Name"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            margin="normal"
            required
          />

          {/* Last Name input field */}
          <TextField
            fullWidth
            label="Last Name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            margin="normal"
            required
          />

          {/* Email input field */}
          <TextField
            fullWidth
            label="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            margin="normal"
            required
            type="email"
          />

          {/* Password input field */}
          <TextField
            fullWidth
            label="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            margin="normal"
            required
            type="password"
            helperText="Password must be at least 6 characters"
          />

          {/* Confirm Password input field */}
          <TextField
            fullWidth
            label="Confirm Password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            margin="normal"
            required
            type="password"
          />

          {/* Submit button */}
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3 }}
          >
            Sign Up
          </Button>
        </Box>
      </Paper>
    </Container>
  );
}
