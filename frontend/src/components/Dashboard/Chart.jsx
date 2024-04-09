import { useEffect, useState } from "react";
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { useSelector, useDispatch } from "react-redux";
import { fetchUsers } from "../../redux/actions/userActions";
import { Grid, Paper } from "@mui/material";

const Chart = () => {
  const dispatch = useDispatch();
  const [genderData, setGenderData] = useState({});
  const [countryData, setCountryData] = useState({});
  const users = useSelector((state) => state.user.users);

  useEffect(() => {
    if (users && users.length === 0) {
      dispatch(fetchUsers());
    }
    if (users && users.length > 0) {
      const genderCounts = users.reduce((acc, user) => {
        acc[user.gender] = (acc[user.gender] || 0) + 1;
        return acc;
      }, {});

      setGenderData(genderCounts);

      const countryCounts = users.reduce((acc, user) => {
        acc[user.country] = (acc[user.country] || 0) + 1;
        return acc;
      }, {});

      setCountryData(countryCounts);
    }
  }, [dispatch, users]);

  const genderOptions = {
    chart: {
      type: "pie",
      height: "80%",
    },
    title: {
      text: "Gender Distribution",
    },
    series: [
      {
        name: "Gender",
        colorByPoint: true,
        data: Object.entries(genderData).map(([gender, count]) => ({
          name: gender,
          y: count,
        })),
      },
    ],
  };

  const ageOptions = {
    chart: {
      type: "column",
      height: "80%",
    },
    title: {
      text: "Country Distribution",
    },
    xAxis: {
      title: {
        text: "Countries",
      },
      categories: Object.keys(countryData),
    },
    yAxis: {
      title: {
        text: "Users",
      },
    },
    series: [
      {
        name: "Number of Users",
        data: Object.entries(countryData).map(([country, count]) => ({
          name: country,
          y: count,
        })),
      },
    ],
  };

  return (
    <Grid
      container
      spacing={2}
      sx={{ justifyContent: "space-around", marginTop: "10px" }}
    >
      <Grid item xs={5}>
        <Paper style={{ padding: "10px" }}>
          <HighchartsReact highcharts={Highcharts} options={genderOptions} />
        </Paper>
      </Grid>
      <Grid item xs={5}>
        <Paper style={{ padding: "10px" }}>
          <HighchartsReact highcharts={Highcharts} options={ageOptions} />
        </Paper>
      </Grid>
    </Grid>
  );
};

export default Chart;
