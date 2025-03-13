import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App";
import "./index.css";
import { ThemeProvider, CssBaseline } from "@mui/material";
import { theme } from "./config/theme";
import { AuthProvider } from "./context/AuthContext";
import { BrowserRouter } from "react-router-dom";

/*
  ThemeProvider: Makes our custom theme available to all components
  CssBaseline: Normalizes styles across browsers
  AuthProvider: Makes authentication functionality available throughout the app
  BrowserRouter: Enables navigation between different pages
*/

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <AuthProvider>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </AuthProvider>
    </ThemeProvider>
  </StrictMode>
);
