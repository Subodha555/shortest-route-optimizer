<script setup lang="ts">
  import {ref} from "vue";

  import {useLoading} from 'vue-loading-overlay';

  import Dropdown from './ui/Dropdown.vue';
  import Button from './ui/Button.vue';
  import searchIllustration from '../assets/searchIllustration.png';
  import IconCalculator from './icons/IconCalculator.vue';
  import Modal from './Modal.vue';
  import {getPath} from '../services/dataAccess';

  type DropdownTypes = {reset: ()=> {}}| null ;

  let fromNode = "";
  let toNode = "";
  let loader = {hide: () => {}};
  const nodesList = ['Select', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'];

  const fromRef = ref<DropdownTypes>(null);
  const toRef = ref<DropdownTypes>(null);
  const fromNodes = ref([...nodesList]);
  const toNodes = ref([...nodesList]);
  const showModal = ref(false);
  const modalMessage = ref('');
  const modalMessageHeader = ref('');
  const modalMessageClasses = ref('');
  const showResults = ref(false);
  const results = ref({nodeNames: [], distance: 0, error: ''});

  const $loading = useLoading({
    color: "#1154A3"
  });

  const onClearSelection = () => {
    fromNode = '';
    toNode = '';
    toNodes.value = [...nodesList];
    fromNodes.value = [...nodesList];
    fromRef.value?.reset();
    toRef.value?.reset();
    showResults.value = false;
    results.value = {nodeNames: [], distance: 0, error: ''};
  };

  const onCalculatePath = async () => {
    if (!fromNode || !toNode) {
      _showModal();
    } else {
      _showLoader();
      const resp = await getPath(fromNode, toNode);

      if (resp.success) {
        results.value = resp;
      } else {
        results.value = {nodeNames: [], distance: 0, error: 'Something went wrong. Please try again.'}
      }

      showResults.value = true;
      loader.hide();
    }
  };

  const onSelectFromNode = (node: string) => {
    fromNode = node;
    toNodes.value = _getFilteredNodes(node);
  };

  const onSelectToNode = (node: string) => {
    toNode = node;
    fromNodes.value = _getFilteredNodes(node);
  };

  const _showModal = () => {
    showModal.value = true;

    let textMessage = "Please select ";

    if (!fromNode) {
      textMessage += 'From Node';
    }

    if (!fromNode && !toNode) {
      textMessage += ' and ';
    }

    if (!toNode) {
      textMessage += 'To Node';
    }

    modalMessage.value = textMessage;
    modalMessageHeader.value = "Error";
    modalMessageClasses.value = "text-red-500";
  };

  const _showLoader = () => {
    loader = $loading.show();
  }

  const _getFilteredNodes = (node: string) => {
    return nodesList.filter((item) => {
      return item !== node;
    });
  };
</script>
<template>
  <div class="flex flex-col md:flex-row w-[300px] sm:w-[500px] md:w-[721px] bg-white rounded-lg z-10 shadow-md" :class="showResults ? 'md:h-[472px]' : 'md:h-[344px]'">
    <div class="flex-1">
      <div class="pr-[24px] pt-[32px] pl-[32px] pb-[32px]">
        <h2 class="text-[20px] leading-[28px] font-semibold text-[#1154A3] mb-4">Select Path</h2>
        <Dropdown ref="fromRef" label="From Node" :options="fromNodes" @select="onSelectFromNode" :selectedItems="fromNodes[0]" />
        <Dropdown ref="toRef" class="mt-[24px]" label="To Node" :options="toNodes" @select="onSelectToNode" :selectedItem="toNodes[0]" />
        <div class="flex mt-[24px] gap-[16px]">
          <Button @click="onClearSelection" buttonClass="text-[#DA753C] border border-[#DA753C] hover:text-orange-600 hover:border-orange-600">Clear</Button>
          <Button @click="onCalculatePath" buttonClass="bg-[#DA753C] text-white hover:bg-orange-600" :icon="IconCalculator">Calculate</Button>
        </div>
      </div>
    </div>

    <div v-if="showResults" class="flex-1 bg-[#F2F3F6] rounded-lg">
      <div class="p-[32px] h-full">
        <div class="text-[16px] leading-[20px] font-semibold text-[#1154A3] pb-[16px]">Result</div>
        <div class="text-[14px] leading-[18px] text-[#5A5B5D] rounded-lg bg-white p-[24px] h-[364px]">
          <div v-if="!results.error">
            <div>From Node Name = “{{results.nodeNames[0]}}”, To Node Name = ”{{results.nodeNames[results.nodeNames.length - 1]}}”:
              <span v-for="(nodeName, index) in results.nodeNames" :key="nodeName">
              <span v-if="index">, </span>
              <span>{{nodeName}}</span>
            </span>
            </div>
            <div class="pt-[10px]">Total Distance: {{results.distance}}</div>
          </div>
          <div v-else class="text-red-500">{{results.error}}</div>
        </div>
      </div>
    </div>
    <div v-else class="flex-1 flex justify-center items-center order-first md:order-last">
      <img :src="searchIllustration" alt="Illustration" class="h-auto w-[185.9px]" />
    </div>
  </div>
  <Modal v-model="showModal" :message="modalMessage" :messageHeader="modalMessageHeader" :messageClasses="modalMessageClasses"/>
</template>