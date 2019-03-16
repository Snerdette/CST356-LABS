<template>
    <div>
        <div v-if='operation == "list"'>
            <h2 class='section-heading'>Persons</h2>
            <table>
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Middle Name</th>
                        <th>Last Name</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="person in persons" :key="person.personId">
                        <td>{{ person.first_name }}</td>
                        <td>${{ person.middle_name }}</td>
                        <td>${{ person.last_name }}</td>
                        <td>
                            <button v-on:click='displayPersonDetails(person.personId)'>Details</button>
                            <button v-on:click='displayUpdatePerson(person.personId)'>Update</button>
                            <button v-on:click='deletePerson(person.personId)'>Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <button id='addBtn' v-on:click='displayAddPerson()'>Add Person</button>
        </div>

        <div v-if='operation == "add"'>
            <h2 class='section-heading'>Add Person</h2>
        
            <form>
                <div class='form-entry'>
                    First Name: <input type='text' v-model='first_name'/>
                </div>

                <div class='form-entry'>
                    Middle Name: <input type='text' v-model='middle_name'/>
                </div>

                <div class='form-entry'>
                    Last Name: <input type='text' v-model='last_name'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='addProduct'>Add Person</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>

        </div>

        <div v-if='operation == "detail"'>
            <h2 class='section-heading'>Person Detail</h2>

            <div class='form-entry'>
                First Name: {{ first_name }}
            </div>

            <div class='form-entry'>
                Middle Name: {{ middle_name }}
            </div>

            <div class='form-entry'>
                Last Name: {{ last_name }}
            </div>

            <div class='form-entry'>
                <button v-on:click='cancel'>Ok</button>
            </div>
        </div>

        <div v-if='operation == "update"'>
            <h2 class='section-heading'>Update Person</h2>
        
            <form>
                <div class='form-entry'>
                    First Name: <input type='text' v-model='first_name'/>
                </div>

                <div class='form-entry'>
                    Middle Name: <input type='text' v-model='middle_name'/>
                </div>

                <div class='form-entry'>
                    Last Name: <input type='text' v-model='last_name'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='updateProduct'>Update Persons</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';

    export default {
        name: 'person',
        props: ['auth'],
        
        data () {
            return {
                persons: [],
                operation: 'list',
                first_name: undefined,
                middle_name: undefined,
                last_name: undefined,
                personUpdateId: undefined
            }
        },

        methods: {
            
            getAuthHeader: function() {
                return {
                    headers: {
                        Authorization: 'Bearer ' + this.auth.accessToken
                    }
                }
            },

            getPersons: function() {
                let url = process.env.PERSON_API;

                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.persons = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            getPerson: function(personId) {
                let url = `${process.env.PERSON_API}/${personId}`;

                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.first_name = response.data.first_name;
                        this.middle_name = response.data.middle_name;
                        this.last_name = response.data.last_name;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            displayAddPerson: function(personId) {
                this.first_name = undefined;
                this.middle_name = undefined;
                this.last_name = undefined;

                this.operation = 'add';
            },

            addPerson: function(personId) {
                let url = `${process.env.PERSON_API}`;

                Vue.axios.post(url, {
                    first_name: this.first_name,
                    middle_name: this.middle_name,
                    last_name: this.last_name
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getPersons();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            displayPersonDetails: function(personId) {
                this.getPerson(personId);

                this.operation = 'detail';
            },

            displayUpdatePerson: function(personId) {
                this.personUpdateId = personId;
                this.getPerson(personId);

                this.operation = 'update';
            },

            updatePerson: function(personId) {
                let url = `${process.env.PERSON_API}/${this.personUpdateId}`;

                Vue.axios.put(url, {
                    first_name: this.first_name,
                    middle_name: this.middle_name,
                    last_name: this.last_name
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getPersons();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            deletePerson: function(personId) {
                let url = `${process.env.PERSON_API}/${personId}`;

                Vue.axios.delete(url, this.getAuthHeader()).then(
                    (response) => {
                        this.getPersons();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },

            cancel: function() {
                this.operation = 'list';
            }
        },

        mounted() {
            this.getPersons();
            this.operation = 'list';
        }
    }
</script>

<style scoped>

    table {
        border-collapse: collapse;
    }

    table, th, td {
        border: 1px solid black;
        padding: 10px;
    }

    #addBtn {
        margin-top: 20px;
    }

    .form-entry {
        margin-top: 20px;
    }

</style>