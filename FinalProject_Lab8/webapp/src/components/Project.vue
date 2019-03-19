<template>
    <div>
        <div v-if='operation == "list"'>
            <h2 class='section-heading'>Projects</h2>
            <table>
                <thead>
                    <tr>
                        <th>Project title</th>
                        <th>Type</th>
                        <th>Site</th>
                        <th>Start Date:</th>
                        <th>End Date:</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="project in projects" :key="project.projectId">
                        <td>{{ project.Title }}</td>
                        <td>{{ project.Type }}</td>
                        <td>{{ project.Site }}</td>
                        <td>${{ project.StartDate }}</td>
                        <td>{{ project.EndDate }}</td>
                        <td>
                            <button v-on:click='displayProjectDetails(project.projectId)'>Details</button>
                            <button v-on:click='displayUpdateProject(project.projectId)'>Update</button>
                            <button v-on:click='deleteProject(project.projectId)'>Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <button id='addBtn' v-on:click='displayAddProject()'>Add Project</button>
        </div>

        <div v-if='operation == "add"'>
            <h2 class='section-heading'>Add Project</h2>
        
            <form>
                <div class='form-entry'>
                    Title: <input type='text' v-model='title'/>
                </div>

                <div class='form-entry'>
                    Type: <input type='text' v-model='type'/>
                </div>

                <div class='form-entry'>
                    Site: <input type='text' v-model='site'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='addProject'>Add Project</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>

        </div>

        <div v-if='operation == "detail"'>
            <h2 class='section-heading'>Project Detail</h2>

            <div class='form-entry'>
                title: {{ Title }}
            </div>

            <div class='form-entry'>
                Type: {{ Type }}
            </div>

            <div class='form-entry'>
                Site: {{ Site }}
            </div>

            <div class='form-entry'>
                <button v-on:click='cancel'>Ok</button>
            </div>
        </div>

        <div v-if='operation == "update"'>
            <h2 class='section-heading'>Update Project</h2>
        
            <form>
                <div class='form-entry'>
                    title: {{ Title }}
                </div>

                <div class='form-entry'>
                    Type: {{ Type }}
                </div>

                <div class='form-entry'>
                    Site: {{ Site }}
                </div>

                <div class='form-entry'>
                    <button v-on:click='updateProject'>Update Project</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    export default {
        name: 'project',
        props: ['auth'],
        
        data () {
            return {
                projects: [],
                operation: 'list',
                name: undefined,
                price: undefined,
                count: undefined,
                projectUpdateId: undefined
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
            getProjects: function() {
                let url = process.env.PROJECT_API;
                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.projects = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            getProject: function(projectId) {
                let url = `${process.env.PROJECT_API}/${projectId}`;
                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.Title = response.data.Title;
                        this.Type = response.data.Type;
                        this.Site = response.data.Site;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayAddProject: function(projectId) {
                this.Title = undefined;
                this.Type = undefined;
                this.Site = undefined;
                //this.operation = 'add';
            },
            addProject: function(projectId) {
                let url = `${process.env.PROJECT_API}`;
                Vue.axios.post(url, {
                    Title: this.Title,
                    Type: this.Type,
                    Site: this.Site
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getProjects();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayProjectDetails: function(projectId) {
                this.getProject(projectId);
                //this.operation = 'detail';
            },
            displayUpdateProject: function(projectId) {
                this.projectUpdateId = projectId;
                this.getProject(projectId);
                this.operation = 'update';
            },
            updateProject: function(projectId) {
                let url = `${process.env.PROJECT_API}/${this.projectUpdateId}`;
                Vue.axios.put(url, {
                    Title: this.Title,
                    Type: this.Type,
                    Site: this.Site
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getProjects();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            deleteProject: function(projectId) {
                let url = `${process.env.PROJECT_API}/${projectId}`;
                Vue.axios.delete(url, this.getAuthHeader()).then(
                    (response) => {
                        this.getProjects();
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
            this.getProjects();
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