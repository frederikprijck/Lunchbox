import React from "react";

import { makeStyles } from "@material-ui/core/styles";
import Grid from "@material-ui/core/Grid";
import RecipeCard from "./RecipeCard";

const useStyles = makeStyles(theme => ({
  card: {
    maxWidth: 350
  }
}));

const data = [
  {
    id: 1,
    Title: "Spaghetti Bolognese",
    CreatedBy: "Jeroen Meus",
    Description: "Spaghetti alla Bolognaise",
    Liked: true
  },
  {
    id: 2,
    Title: "Stoofvlees met frietjes",
    CreatedBy: "Jeroen Meus",
    Description: "Met frietjes",
    Liked: false
  },
  {
    id: 2,
    Title: "Goulash met frietjes",
    CreatedBy: "Jeroen Meus",
    Description: "Met frietjes",
    Liked: false
  },
  {
    id: 2,
    Title: "Brandade van Kabeljauw",
    CreatedBy: "Jeroen Meus",
    Description: "Met frietjes",
    Liked: true
  },
  {
    id: 2,
    Title: "Iets anders",
    CreatedBy: "Jeroen Meus",
    Description: "Met frietjes",
    Liked: false
  }
];

export default function RecipeGrid() {
  const classes = useStyles();

  return (
    <Grid container direction={"row"} spacing={2}>
      {data.map(recipe => (
        <Grid item xs={3} className={classes.gridItem}>
          <RecipeCard recipe={recipe}></RecipeCard>
        </Grid>
      ))}
    </Grid>
  );
}
