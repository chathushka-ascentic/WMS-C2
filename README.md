# Workflow Management System
This document contains the basic requirements of the WMS application. The WMS application is focused in create and manage workflows. WMS is built upon a set of targeted high-level requirements.

WMS application should:

1. Allows individuals to automate repetitive processes using a simple flow.
2. Follows up automatically on uncompleted tasks in the process
3. Gives an overall picture of the workflow
4. display as a form of SLA Status Indicators
5. Allow to utilize the process through web services.
6. On top of the above high-level requirements, WMS will be developed for a scoped domain area. Application will be allowed to execute workflows to determine the User Stories created in TFS are ready start work by an agile team. Before start working on a user story, user story should be validated. Validation process defined as workflow activity handler and each activity handler is responsible to reject or approve the user story.

## Features of the Application
Core features of the application

1. Create workflows
2. Update workflows
3. Version control of the workflows
4. Create user stories
5. Update user stories
6. Run workflows at each create/update of user story

Out of scope

1. Authentication and authorization
2. Client-side validation
3. Log and trace
