// This file contains the Header component which appears at the top of every page in the application

// Import necessary Material UI components for the header layout and styling
import {
  AppBar,
  Toolbar,
  Typography,
  Button,
  Box,
  Avatar,
  Menu,
  MenuItem,
} from "@mui/material";
// AppBar: Creates a top navigation bar
// Toolbar: Container for content within AppBar
// Typography: For text styling
// Button: For clickable buttons
// Box: General layout container
// Avatar: Circular component for user profile pictures
// Menu: Dropdown menu
// MenuItem: Option within a dropdown menu

import { primaryColor } from "../config/theme";

// Import icon from Lucide React icon library
import { Waves } from "lucide-react";

// Import navigation functionality from React Router
import { useNavigate } from "react-router-dom";

// Import our authentication hook to access user data and logout function
import { useAuth } from "../context/AuthContext";

// Import useState hook for managing the dropdown menu state
import { useState } from "react";

// Define and export the Header component
export function Header() {
  // Initialize the navigate function from React Router to handle navigation
  const navigate = useNavigate();

  // Get user data and logout function from the AuthContext
  const { user, logout } = useAuth();

  // State to control the user dropdown menu
  // anchorEl stores the element that the menu should be positioned against
  // Initially null (menu closed)
  const [anchorEl, setAnchorEl] = useState(null);

  // Function to open the dropdown menu when user clicks on their avatar
  const handleMenu = (event) => {
    // Set the anchorEl to the element that was clicked (the avatar)
    // event.currentTarget is the element that was clicked
    setAnchorEl(event.currentTarget);
  };

  // Function to close the dropdown menu
  const handleClose = () => {
    // Reset anchorEl to null which closes the menu
    setAnchorEl(null);
  };

  // Function to handle user logout
  const handleLogout = () => {
    // Call the logout function from AuthContext
    logout();
    // Close the dropdown menu
    handleClose();
    // Navigate to the home page
    navigate("/");
  };

  return (
    // AppBar creates a top navigation bar that sticks to the top of the page
    <AppBar
      position="sticky" // sticky is better that fixed (default) because other elements are taken into account
      sx={{
        // Custom styles
        backgroundColor: "#0d98ba", // White background
        color: "#222222", // Dark text color
        boxShadow: "0 1px 0 rgba(0,0,0,0.08)", // Subtle bottom border shadow
      }}
    >
      {/* Toolbar contains the content of the header */}
      <Toolbar>
        {/* Box for the logo and brand name */}
        <Box
          sx={{
            display: "flex", // Horizontal layout
            alignItems: "center", // Center items vertically
            cursor: "pointer", // Change cursor to hand on hover
          }}
          onClick={() => navigate("/")} // Navigate to home page when clicked
        >
          {/* Waves icon as the logo */}
          <Waves size={32} color={primaryColor} />

          {/* App name */}
          <Typography
            variant="h6"
            sx={{
              ml: 1, // Margin left (1 * 8px = 8px)
              fontWeight: 700, // Bold text
              color: primaryColor, // Brand color (blue)
            }}
          >
            Surfing Point
          </Typography>
        </Box>

        {/* Flexible space that pushes the next elements to the right */}
        <Box sx={{ flexGrow: 1 }} />

        {/* Conditional rendering based on authentication status */}
        {user ? (
          // If user is logged in, show avatar and dropdown menu
          <UserButton
            user={user}
            handleMenu={handleMenu}
            handleClose={handleClose}
            anchorEl={anchorEl}
            handleLogout={handleLogout}
          />
        ) : (
          // If no user is logged in, show sign in and sign up buttons
          <AuthButtons navigate={navigate} />
        )}
      </Toolbar>
    </AppBar>
  );
}

function UserButton({ user, handleMenu, handleClose, anchorEl, handleLogout }) {
  return (
    <>
      {/* User avatar - displays the first letter of the user's email */}
      <Avatar
        onClick={handleMenu} // Open dropdown menu when clicked
        sx={{
          cursor: "pointer", // Change cursor to hand on hover
          bgcolor: "#222222", // Dark background
          "&:hover": { opacity: 0.8 }, // Fade effect on hover
        }}
      >
        {user.email[0].toUpperCase()} {/* First letter of email, capitalized */}
      </Avatar>

      {/* Dropdown menu for user options */}
      <Menu
        anchorEl={anchorEl} // Element to anchor the menu to (the avatar)
        open={Boolean(anchorEl)} // Menu is open when anchorEl is not null
        onClose={handleClose} // Close menu when clicking outside
        PaperProps={{
          // Styling for the menu paper
          sx: {
            mt: 1, // Margin top
            boxShadow: "0 2px 16px rgba(0,0,0,0.12)", // Shadow for depth
            borderRadius: 2, // Rounded corners
          },
        }}
      >
        {/* Logout menu item */}
        <MenuItem
          onClick={handleLogout} // Call handleLogout when clicked
          sx={{
            fontSize: "0.95rem", // Font size
            py: 1.5, // Padding top and bottom
            px: 3, // Padding left and right
          }}
        >
          Logout
        </MenuItem>
        <MenuItem
          sx={{
            fontSize: "0.95rem", // Font size
            py: 1.5, // Padding top and bottom
            px: 3, // Padding left and right
          }}
        >
          More options...
        </MenuItem>
        <MenuItem
          sx={{
            fontSize: "0.95rem", // Font size
            py: 1.5, // Padding top and bottom
            px: 3, // Padding left and right
          }}
        >
          More options...
        </MenuItem>
      </Menu>
    </>
  );
}

function AuthButtons({ navigate }) {
  return (
    <>
      {/* Sign In button */}
      <Button
        onClick={() => navigate("/signin")} // Navigate to sign in page when clicked
        sx={{
          color: "#222222", // Dark text
          textTransform: "none", // Prevents all-caps text
          fontWeight: 500, // Medium font weight
          "&:hover": { bgcolor: "rgba(0,0,0,0.04)" }, // Light gray background on hover
        }}
      >
        Sign In
      </Button>

      {/* Sign Up button */}
      <Button
        onClick={() => navigate("/signup")} // Navigate to sign up page when clicked
        sx={{
          color: "#222222", // Dark text
          textTransform: "none", // Prevents all-caps text
          fontWeight: 500, // Medium font weight
          "&:hover": { bgcolor: "rgba(0,0,0,0.04)" }, // Light gray background on hover
        }}
      >
        Sign Up
      </Button>
    </>
  );
}
