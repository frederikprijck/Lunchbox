import React from "react";

import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import IconButton from "@material-ui/core/IconButton";
import FavoriteIcon from "@material-ui/icons/Favorite";
import { CardHeader, Avatar } from "@material-ui/core";
import { fade, makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";

const data = [{
  id: 1,
  Title: "Spaghetti Bolognese",
  CreatedBy: "Jeroen Meus",
  Description: "Spaghetti alla Bolognaise",
  Liked: true
},
{
    id: 2,
    Title: "Stoofvlees",
    CreatedBy: "Jeroen Meus",
    Description: "Met frietjes",
    Liked: false
  },
]

const useStyles = makeStyles(theme => ({
  card: {
    maxWidth: 350
  },
  media: {
    height: 140
  },
  like: {
    color: "red"
  }
}));

export default function SearchAppBar() {
  const classes = useStyles();

  return ( data.map(d => 
    <Card className={classes.card}>
      <CardHeader
        avatar={
          <Avatar src="https://scontent.fbru2-1.fna.fbcdn.net/v/t1.0-9/19260293_10212076719087639_5730265156197589_n.jpg?_nc_cat=104&_nc_oc=AQkfN_WajIYaCSK96RJogF5SysK7Z9kwBqYEsppZArs5uxuHY2SROrkJauDYe2-cNZs&_nc_ht=scontent.fbru2-1.fna&oh=6684668a678e5f0dd8b8489ad061f517&oe=5E3B2782"></Avatar>
        }
        title={d.Title}
        subheader={d.CreatedBy}
        action={
          <IconButton className={d.Liked ? classes.like : ''}>
            <FavoriteIcon />
          </IconButton>
        }
      ></CardHeader>
      <CardActionArea>
        <CardMedia
          className={classes.media}
          image="https://images.vrt.be/dako2017_1600s_j75/2018/04/10/8773338f-3cd3-11e8-abcc-02b7b76bf47f.jpg"
          title="Spaghetti"
        />
        <CardContent>
          <Typography variant="body2" color="textSecondary" component="p">
            {d.Description}
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary">
          Bekijk recept
        </Button>
      </CardActions>
    </Card>
  ));
}
