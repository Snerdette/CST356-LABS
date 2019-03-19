<template>
    <div>
        <div v-if='operation == "list"'>
            <h2 class='section-heading'>My Event</h2>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Location</th>
                        <th>Date:</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="event in events" :key="event.eventId">
                        <td>{{ event.Name }}</td>
                        <td>{{ event.Location }}</td>
                        <td>{{ event.Date }}</td>
                        <td>
                            <button v-on:click='displayEventDetails(event.eventId)'>Details</button>
                            <button v-on:click='displayUpdateEvent(event.eventId)'>Update</button>
                            <button v-on:click='deleteEvent(event.eventId)'>Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <button id='addBtn' v-on:click='displayAddEvent()'>Add Event</button>
        </div>

        <div v-if='operation == "add"'>
            <h2 class='section-heading'>Add Event</h2>
        
            <form>
                <div class='form-entry'>
                    Name: <input type='text' v-model='Name'/>
                </div>

                <div class='form-entry'>
                    Location: <input type='text' v-model='Location'/>
                </div>

                <div class='form-entry'>
                    Date: <input type='text' v-model='date'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='addEvent'>Add Event</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>

        </div>

        <div v-if='operation == "detail"'>
            <h2 class='section-heading'>Event Detail</h2>

            <div class='form-entry'>
                Name: {{ Name }}
            </div>

            <div class='form-entry'>
                Location: {{ Location }}
            </div>

            <div class='form-entry'>
                Date: {{ Date }}
            </div>

            <div class='form-entry'>
                <button v-on:click='cancel'>Ok</button>
            </div>
        </div>

        <div v-if='operation == "update"'>
            <h2 class='section-heading'>Update Event</h2>
        
            <form>
               <div class='form-entry'>
                    Name: {{ Name }}
                </div>

                <div class='form-entry'>
                    Location: {{ Location }}
                </div>

                <div class='form-entry'>
                    Date: {{ Date }}
                </div>

                <div class='form-entry'>
                    <button v-on:click='updateEvent'>Update Event</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    export default {
        name: 'event',
        props: ['auth'],
        
        data () {
            return {
                events: [],
                operation: 'list',
                Name: undefined,
                Location: undefined,
                Date: undefined,
                eventUpdateId: undefined
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
            getEvents: function() {
                let url = process.env.EVENT_API;
                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.events = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            getEvent: function(eventId) {
                let url = `${process.env.EVENT_API}/${eventId}`;
                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.Name = response.data.Name;
                        this.Location = response.data.Location;
                        this.Date = response.data.Date;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayAddEvent: function(eventId) {
                this.Name = undefined;
                this.Location = undefined;
                this.Date = undefined;
                this.operation = 'add';
            },
            addEvent: function(eventId) {
                let url = `${process.env.EVENT_API}`;
                Vue.axios.post(url, {
                    Heading: this.Heading,
                    Body: this.Body,
                    Date: this.Date
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getEvents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayEventDetails: function(eventId) {
                this.getEvent(eventId);
                this.operation = 'detail';
            },
            displayUpdateEvent: function(eventId) {
                this.eventUpdateId = eventId;
                this.getEvent(eventId);
                this.operation = 'update';
            },
            updateEvent: function(eventId) {
                let url = `${process.env.EVENT_API}/${this.eventUpdateId}`;
                Vue.axios.put(url, {
                    Heading: this.Heading,
                    Body: this.Body,
                    Date: this.Date
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getEvents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            deleteEvent: function(eventId) {
                let url = `${process.env.EVENT_API}/${eventId}`;
                Vue.axios.delete(url, this.getAuthHeader()).then(
                    (response) => {
                        this.getEvents();
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
            this.getEvents();
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
    .onSale {
        background-color: lightgreen;
    }
    .lowInventory {
        font-weight: bold;
        background-color: yellow;
    }
</style>