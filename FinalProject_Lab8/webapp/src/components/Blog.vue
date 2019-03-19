<template>
    <div>
        <div v-if='operation == "list"'>
            <h2 class='section-heading'>My Blog</h2>
            <table>
                <thead>
                    <tr>
                        <th>Blog Heading</th>
                        <th>Type</th>
                        <th>Site</th>
                        <th>Start Date:</th>
                        <th>End Date:</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="blog in blogs" :key="blog.blogId">
                        <td>{{ blog.Heading }}</td>
                        <td>{{ blog.Body }}</td>
                        <td>{{ blog.Date }}</td>
                        <td>
                            <button v-on:click='displayBlogDetails(blog.blogId)'>Details</button>
                            <button v-on:click='displayUpdateBlog(blog.blogId)'>Update</button>
                            <button v-on:click='deleteBlog(blog.blogId)'>Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <button id='addBtn' v-on:click='displayAddBlog()'>Add Blog</button>
        </div>

        <div v-if='operation == "add"'>
            <h2 class='section-heading'>Add Blog</h2>
        
            <form>
                <div class='form-entry'>
                    Heading: <input type='text' v-model='Heading'/>
                </div>

                <div class='form-entry'>
                    Body: <input type='text' v-model='Body'/>
                </div>

                <div class='form-entry'>
                    Date: <input type='text' v-model='date'/>
                </div>

                <div class='form-entry'>
                    <button v-on:click='addBlog'>Add Blog</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>

        </div>

        <div v-if='operation == "detail"'>
            <h2 class='section-heading'>Blog Detail</h2>

            <div class='form-entry'>
                Heading: {{ Heading }}
            </div>

            <div class='form-entry'>
                Body: {{ Body }}
            </div>

            <div class='form-entry'>
                Date: {{ Date }}
            </div>

            <div class='form-entry'>
                <button v-on:click='cancel'>Ok</button>
            </div>
        </div>

        <div v-if='operation == "update"'>
            <h2 class='section-heading'>Update Blog</h2>
        
            <form>
                <div class='form-entry'>
                    Heading: {{ Heading }}
                </div>

                <div class='form-entry'>
                    Body: {{ Body }}
                </div>

                <div class='form-entry'>
                    Date: {{ Date }}
                </div>

                <div class='form-entry'>
                    <button v-on:click='updateBlog'>Update Blog</button>
                    <button v-on:click='cancel'>Cancel</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    export default {
        name: 'blog',
        props: ['auth'],
        
        data () {
            return {
                blogs: [],
                operation: 'list',
                Heading: undefined,
                Body: undefined,
                Date: undefined,
                blogUpdateId: undefined
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
            getBlogs: function() {
                let url = process.env.BLOG_API;
                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.blogs = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            getBlog: function(blogId) {
                let url = `${process.env.BLOG_API}/${blogId}`;
                Vue.axios.get(url, this.getAuthHeader()).then(
                    (response) => {
                        this.Heading = response.data.Heading;
                        this.Body = response.data.Body;
                        this.Date = response.data.Date;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayAddBlog: function(blogId) {
                this.Heading = undefined;
                this.Body = undefined;
                this.Date = undefined;
                this.operation = 'add';
            },
            addBlog: function(blogId) {
                let url = `${process.env.BLOG_API}`;
                Vue.axios.post(url, {
                    Heading: this.Heading,
                    Body: this.Body,
                    Date: this.Date
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getBlogs();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayBlogDetails: function(blogId) {
                this.getBlog(blogId);
                this.operation = 'detail';
            },
            displayUpdateBlog: function(blogId) {
                this.blogUpdateId = blogId;
                this.getBlog(blogId);
                this.operation = 'update';
            },
            updateBlog: function(blogId) {
                let url = `${process.env.BLOG_API}/${this.blogUpdateId}`;
                Vue.axios.put(url, {
                    Heading: this.Heading,
                    Body: this.Body,
                    Date: this.Date
                }, this.getAuthHeader()).then(
                    (response) => {
                        this.getBlogs();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            deleteBlog: function(blogId) {
                let url = `${process.env.BLOG_API}/${blogId}`;
                Vue.axios.delete(url, this.getAuthHeader()).then(
                    (response) => {
                        this.getBlogs();
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
            this.getBlogs();
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