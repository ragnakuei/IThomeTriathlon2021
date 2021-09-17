const jquery_ui_dialog = {
    template: `
        <div v-bind:id="id"
             v-bind:title="title">
            <slot name="content"
                  v-if="show_content"></slot>
        </div>
    `,
    props: {
        id : String,
        title : String,
        width : Number,
        height : Number,
    },

    setup(props, { emit }) {

        let dialogDom = null;

        const show_content = ref(false);

        onMounted(() => {

            dialogDom = $( '#' + props.id );
            dialogDom.dialog({
                autoOpen: false,
                height: props.height,
                width: props.width,
                modal: true
            });
        })

        const open = function() {
            dialogDom.dialog( "open" );
            show_content.value = true;

            $('.ui-widget-overlay').on('click', function()
            {
                close();
            });
        }

        const close = function() {
            show_content.value = false;
            dialogDom.dialog( "close" );
        }

        return {
            show_content,
            open,
            close,
        }
    },
}
