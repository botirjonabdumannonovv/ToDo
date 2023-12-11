<template>

    <div class="h-full w-full p-20 flex flex-col gap-y-20 px-[20%] items-center justify-center">

          <!-- Todo list -->
          <todo-list :todos="todos" @editTodo="onEditTodo"/>

          <!-- New todo form  -->
          <new-todo-form @addNewTodo="onAddTodo" :edit-todo="editTodo"/>

    </div>

</template>

<script>

import {ToDoApiClient} from "@/infrastructure/apiClients/toDoApiClient/brokers/ToDoApiClient.js";
import {onBeforeMount, ref} from "vue";
import {ToDoItem} from "@/modules/todos/models/ToDoItem.js";
import {defineComponent} from "vue";
import TodoList from "@/modules/todos/components/TodoList.vue";
import NewTodoForm from "@/modules/todos/components/NewTodoForm.vue";

export default defineComponent({
  components: {NewTodoForm, TodoList}
})


const todoApiClient = new ToDoApiClient();
const todos = ref<ToDoItem[]>([]);
const editTodo = ref<ToDoItem | null>(null);

onBeforeMount(async () => {
    await loadTodoAsync();
});

const loadTodoAsync = async () =>{
    const todosResponse = await todoApiClient.todos.getAsync();
    if(todosResponse.isSuccess && todosResponse.response){
        todos.value = todosResponse.response;
    }
}

const onAddTodo = (todo: ToDoItem) => {
    todos.value.push(todo);
}

const onEditTodo = (id: Guid) =>{
    const todo = todos.value.find(x => x.id === id);
    if(todo){
        editTodo.value = todo;
    }
}

</script>