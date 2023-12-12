<template>

    <div class="h-full w-full p-20 flex flex-col gap-y-20 px-[20%] items-center justify-center">

          <!-- Todo list -->
          <todo-list :todos="todos" @editTodo="onEditTodo"/>

          <!-- New todo form  -->
          <new-todo-form @addNewTodo="onAddTodo" :edit-todo="editTodo"/>

    </div>

</template>

<script setup lang="ts">

import {ToDoApiClient} from "@/infrastructure/apiClients/toDoApiClient/brokers/ToDoApiClient";
import {onBeforeMount, ref} from "vue";
import {ToDoItem} from "@/modules/todos/models/ToDoItem";
import {defineComponent} from "vue";
import NewTodoForm from "@/modules/todos/components/TodoForm.vue";
import TodoList from "@/modules/todos/components/TodoList.vue";
import type {Guid} from "guid-typescript";



const todoApiClient = new ToDoApiClient();
const todos = ref<ToDoItem[]>([]);
const editTodo = ref<ToDoItem | null>(null);

onBeforeMount(async () => {
    await loadTodoAsync();
});

const loadTodoAsync = async () => {
    const todosResponse = await todoApiClient.todos.getAsync();
    if(todosResponse.isSuccess && todosResponse.response){
        todos.value = todosResponse.response;
    }
}

const onAddTodo = (todo: ToDoItem) => {
    todos.value.push(todo);
}

const onEditTodo = (id: Guid) => {
    const todo = todos.value.find(x => x.id === id);
    if(todo){
        editTodo.value = todo;
    }
}

</script>