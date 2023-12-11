<template>

    <div class="flex flex-col gap-4 w-full h-[800px] overflow-x-scroll no-scrollbar">

        <todo-card v-for="todo in todos" :todo="todo" :key="todo.id" @editTodo="onEditTodo" @deleteTodo="onDeleteTodo"/>

    </div>

</template>

<script>

import {ToDoItem} from "@/modules/todos/models/ToDoItem.js";
import {defineComponent} from "vue";
import TodoCard from "@/modules/todos/components/TodoCard.vue";

export default defineComponent({
  components: {TodoCard}
})


const props = defineProps({
  todos: {
    type: Array as PropType<Array<ToDoItem>>,
    required: true
  }
});

const emit = defineEmits<{editTodo: [todo: ToDoItem],}>();

const onEditTodo = (id: Guid) => {
    emit("editTodo", id);
}

const onDeleteTodo = (id: Guid) => {
    const index = props.todos.findIndex(x => x.id === id);
    if(index !== -1){
        props.todos.splice(index, 1);
    }
}

</script>