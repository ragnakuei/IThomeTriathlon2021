const jquery_ui_select_menu = {
    template: `
        <select v-bind:id="id"
                v-model="modelValue">
            <option value="null">請選擇</option>
            <option v-for="(item, item_index) in options_value"
                    v-bind:key="item.Value"
                    v-bind:value="item.Value">
                {{ item.Text }}
            </option>
        </select>
    `,
    props: {
        id: String,
        options : Array,
        modelValue: Number,
        width: Number,
    },
    setup(props, {emit}) {

        const options_value = ref(props.options || []);
        let dom = null;

        onMounted(() => {
            dom = $("#"+ props.id);
            dom.selectmenu({
                width: props.width,
                change: function (event, ui) {
                    emit('update:modelValue', parseInt(ui.item.value));
                    emit('change', parseInt(ui.item.value))
                }
            });
        })

        const update_options = async function (import_options) {
            options_value.value =  import_options;

            if(dom.selectmenu( "instance" )) {
                await nextTick();
                dom.selectmenu( "refresh" );
            }
        }

        return {
            options_value,
            update_options,
        }
    },
}
