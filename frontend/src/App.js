import React from "react";
import SearchAppBar from "./components/SearchAppBar";
import RecipeGrid from "./components/RecipeGrid";
import Typography from "@material-ui/core/Typography";
import Container from "@material-ui/core/Container";

function App() {
  return (
    <div className="App">
      <SearchAppBar />
      <Container>
        <Typography variant="h2">Featured recipes</Typography>
        <RecipeGrid></RecipeGrid>
      </Container>
    </div>
  );
}

export default App;
