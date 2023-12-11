<template>

  <article class="flex flex-col w-screen h-screen">

      <todo-container/>

  </article>

</template>

<script setup lang="ts">
import TodoContainer from "@/modules/todos/components/TodoContainer.vue";
import TodoList from "@/modules/todos/components/TodoList.vue";
import TodoCard from "@/modules/todos/components/TodoCard.vue";
</script>