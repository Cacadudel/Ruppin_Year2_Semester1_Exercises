import { Routes, Route } from "react-router-dom";

import { HomePage } from "./pages/HomePage";
import { BeachDetailsPage } from "./pages/BeachDetailsPage";
import { SignInPage } from "./pages/SignInPage";
import { SignUpPage } from "./pages/SignUpPage";

import { Header } from "./components/Header";
import Footer from "./components/Footer";
import { Box } from "@mui/material";

// Main App component that sets up the structure of our application
function App() {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        minHeight: "100vh",
      }}
    >
      {/* Header component appears on all pages */}
      <Header />
      {/* Routes define which component should be shown at each URL path */}
      <Box
        component="main"
        sx={{ flexGrow: 1 }}
      >
        <Routes>
          {/* Route for the home page (main landing page) */}
          <Route
            path="/"
            element={<HomePage />}
          />

          {/* Route for beach details page - ":id" is a dynamic parameter that will be the beach identifier */}
          <Route
            path="/beaches/:id"
            element={<BeachDetailsPage />}
          />

          {/* Route for the sign in (login) page */}
          <Route
            path="/signin"
            element={<SignInPage />}
          />

          {/* Route for the sign up (registration) page */}
          <Route
            path="/signup"
            element={<SignUpPage />}
          />
        </Routes>
      </Box>

      {/* Footer component appears on all pages */}
      <Footer />
    </Box>
  );
}

export default App;
