import { createTheme } from "@mui/material";

// Primary color for the app
// we are exporting the primary color so it can be used in other files (mainly in svg icons)
export const primaryColor = "#87CEEB";

// Create a custom theme for our application using Material UI
// This defines colors, typography, and other visual elements
export const theme = createTheme({
  palette: {
    primary: {
      main: primaryColor, // Main brand color (sea blue like sky)
    },
    background: {
      default: "#0d98ba", // White background for the app
    },
  },
  typography: {
    fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif', // Font family for text
  },
});
