// This file contains the SignInPage component for user login

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

// Define and export the SignInPage component
export function SignInPage() {
  // State to store form input values
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  // State to store error messages
  const [error, setError] = useState("");

  // Get the navigate function to redirect after login
  const navigate = useNavigate();
  // Get the login function from our auth context
  const { login } = useAuth();

  // Handle form submission
  const handleSubmit = (e) => {
    // Prevent the default form submission behavior
    e.preventDefault();
    // Clear any previous errors
    setError("");

    // Call the login function from our AuthContext
    // This will check if email/password match a user in mockUsers
    const result = login(email, password);

    // If login was successful, navigate to the home page
    if (result.success) {
      navigate("/");
    } else {
      // If login failed, show the error message
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
          Sign In
        </Typography>

        {/* Show error message if there is one */}
        {error && (
          <Typography
            color="error"
            align="center"
            sx={{ mb: 2 }}
          >
            {error}
          </Typography>
        )}

        {/* Login form */}
        <Box
          component="form"
          onSubmit={handleSubmit}
        >
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
          />

          {/* Submit button */}
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3 }}
          >
            Sign In
          </Button>

          {/* Helper text for new users */}
          <Typography
            variant="body2"
            align="center"
            sx={{ mt: 2 }}
          >
            For testing, use: john@example.com / password123
          </Typography>
        </Box>
      </Paper>
    </Container>
  );
}
