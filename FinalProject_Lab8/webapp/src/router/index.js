import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Project from '@/components/Project'
import Event from '@/components/Event'
import Blog from '@/components/Blog'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/project',
      name: 'Project',
      component: Project
    },
    {
      path: '/event',
      name: 'Event',
      component: Event
    },
    {
      path: '/blog',
      name: 'Blog',
      component: Blog
    },
  ]
})
