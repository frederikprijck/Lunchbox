import React from "react";

import { makeStyles } from "@material-ui/core/styles";
import Grid from "@material-ui/core/Grid";
import RecipeCard from "./RecipeCard";

const useStyles = makeStyles(theme => ({
  card: {
    maxWidth: 350
  }
}));

class RecipeGrid extends React.Component {
    constructor(props) {
        super(props);
        this.state = {recipes : []};
    }

    componentDidMount() {
        fetch('http://localhost:5000/api/Recipes')
        .then(response => response.json())
        .then(data => this.setState({recipes : data}));
    }

  render() {return (
    <Grid container direction={"row"} spacing={2}>
      {this.state.recipes.map(recipe => (
        <Grid item xs={3} key={recipe.id}>
          <RecipeCard recipe={recipe}></RecipeCard>
        </Grid>
      ))}
    </Grid>
  );}
}

export default RecipeGrid;