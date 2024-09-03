<script setup lang="ts">
  type Props = {
    buttonClass: string,
    icon?: object
  }

  const props = defineProps<Props>();

  const emit = defineEmits<{
    (e: 'click'): void;
  }>();
</script>

<template>
  <button @click="emit('click')" class="rounded-[8px] px-[16px] py-[12px] text-[16px] leading-[20px] flex gap-[16px]" :class="buttonClass">
    <slot></slot>
    <span v-if="icon">
      <icon/>
    </span>
  </button>
</template>
