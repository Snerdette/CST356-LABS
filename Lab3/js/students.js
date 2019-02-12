function initializeStudents() {
    var data = getTestStudents();
    displayStudents(data.students);
}

function getTestStudents() {
    return JSON.parse(testStudents);
}

function displayStudents(students) {

    for(i = 0; i < students.length; i++) {

        console.log('name: ' + students[i].name);
        
        var fname = students[i].fname;
        var lname = students[i].lname;
        var id = students[i].id;
        var email = students[i].email;
        var enrolled = students[i].enrolled ? 'yes' : 'no';
        var markup = "<tr><td>" + fname + " " + lname + "</td><td>$" + id + "</td><td>" + enrolled + "</td></tr>";

        $("table tbody").append(markup);
    }
}

var testStudents = '{"students": [
	{"fname": "Ray", "lname": "Ramano", "id": 1 ,"enrolled": true},
	{"fname": "Dane", "lname": "Cook", "id": 2 ,"enrolled": true},
	{"fname": "Will", "lname": "Ferral", "id": 3 ,"enrolled": true}

	]
}'
