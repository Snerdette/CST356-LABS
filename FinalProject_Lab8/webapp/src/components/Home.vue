<template>
<div>
  <header>
        <div>
            <div>Welcome</div>
            <img src="../assets/1000px-HawthorneBridge-Pano.jpg" alt="Hawthorne Bridge">
            <div id="homeHeader"><h2>Lab 1</h2></div>
            <p>^ This is My Home Page</p>
        </div>
        <br>
        <div class="navBar">
            <ul>
                <li><span href="index.html">Home Page</span></li>
                <li><span href="project.html">Projects Page</span></li>
                <li><span href="event.html">Events Page</span></li>
                <li><span href="blog.html">My Blog</span></li>
                <li><span href="login.html">Login/Out</span></li>
            </ul>
        </div>
    </header>

    <div id="dateAndTime">
        <button type="button" onclick="document.getElementById('demo').innerHTML = Date()">
                Click me to display Date and Time.</button>

            <p id="demo"></p>
    </div>

    <div id="paragraphs">
        <div>
            <h4>Projects Page</h4>
            <p>The Projects page holds a list of all the projects i've worked on, some are linked to events and blog posts but others are not.</p>
        </div>
        <div>
            <h4>Events Page</h4>
            <p>The Events Page holds a lit of events that are sometimes linked to events and related blog posts.</p>
        </div>
        <div>
            <h4>My Blog</h4>
            <p>My blog hold everything from rants and raves to my opinion on a tv show, it is sometimes linked to Projects and Events.</p>
        </div>
    </div>
</div>
</template>

<script>
  // var authService = require('../auth/AuthService');
  export default {
    name: 'home',
    data () {
      return {
        error: ''
      }
    },
    // methods: {
    //     login: function() {
    //       authService.login();
    //     }
    // },
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

body {
    background-color: lightblue;

}

/*
    I was unsure if you wanted us to use "th" for the group, or make our own. So i did both but they have the same specs.
 */
.tableHeader {
    font-family: Elephant;
}
h2 {
    text-align: center;
}
th {
    font-family: Elephant;
}

#homeHeader {
    color: coral;
    font-family: "Courier New";
}

.navBar {
    background-color: white;
    padding: 5px;
    margin: 1px;
    border: 2px dotted black;
}

#paragraphs {
    padding: 5px;
    margin: 1px;
    border: 1px solid darkblue;
}

#dateAndTime {
    border: 2px solid black;
    padding: 15px;
    margin: 15px;
}

table, th, td {
    border: 1px solid black;
}

table {
    width: 100%;
    text-align: center;
}

th {
    height: 50px;
}

li {
    display: inline;
    padding-left:50px;
}

ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
}
</style>
