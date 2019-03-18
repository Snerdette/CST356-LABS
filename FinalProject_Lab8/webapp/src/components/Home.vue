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
                <li><span href="person.html">Person Page</span></li>
                <li><span href="students.html">Student Page</span></li>
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
            <h4>Article 1</h4>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin egestas commodo mollis. Nunc sit amet dui ac arcu pulvinar blandit at nec mauris. Maecenas sit amet hendrerit est, sed elementum justo. Maecenas sollicitudin orci sed convallis varius. Morbi vel sapien et libero auctor pretium ut a dui. Nulla eget ultrices elit, nec aliquet felis. Integer gravida ligula placerat enim eleifend, eu dignissim arcu malesuada. Etiam imperdiet efficitur sem, sed rutrum augue commodo ut. Nullam libero nisi, eleifend id lorem tristique, egestas eleifend lacus. In luctus diam nec felis consequat, vel egestas erat faucibus. Sed ultricies sapien nisi. Nunc turpis enim, blandit laoreet sagittis eu, tincidunt nec felis. Aliquam sit amet molestie nisi. Aenean tincidunt porta sem id sollicitudin. Ut iaculis, massa aliquam dictum convallis, eros turpis semper nulla, ac aliquet felis dui nec urna. Duis tempor, mauris et interdum tincidunt, turpis elit dictum nulla, ut accumsan dolor ligula sed ligula.</p>
        </div>
        <div>
            <h4>Article 2</h4>
            <p>In luctus eu lectus eget vehicula. Suspendisse vitae elit viverra, consectetur tortor non, lobortis quam. In commodo sapien a enim pharetra imperdiet. Cras est dui, tristique ac hendrerit a, varius nec lectus. Nulla iaculis metus neque, ultrices consequat ante molestie ac. Sed vestibulum risus vitae lacus vulputate porttitor. Integer dui dui, euismod non eleifend vulputate, luctus a lorem. Nunc nisl arcu, congue ut cursus ut, lobortis eu sem. Etiam blandit ipsum ultrices fermentum semper. Vivamus sodales, enim nec finibus blandit, mi mauris vulputate velit, sed placerat risus sem et nulla. Morbi vulputate sit amet magna nec facilisis. Proin eget elit nec dui laoreet commodo. Vestibulum convallis dapibus turpis at fermentum. Curabitur in mauris velit. Suspendisse maximus rutrum mattis.</p>
        </div>
        <div>
            <h4>Article 3</h4>
            <p>Vivamus condimentum vestibulum orci, eu tristique nisl. Etiam id tempor felis, at facilisis risus. Vestibulum facilisis a nulla in fermentum. Vivamus quam ex, euismod non volutpat et, pulvinar eu tellus. Cras a sem vel arcu vestibulum porta. Proin facilisis urna id semper convallis. Nunc mattis sit amet massa at vehicula.</p>
        </div>
    </div>
</div>
</template>

<script>
export default {
  name: 'Home',
  data () {
    return {

    }
  }
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
