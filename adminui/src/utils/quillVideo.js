import Quill from 'quill'

const BlockEmbed = Quill.import('blots/block/embed')

class VideoBlot extends BlockEmbed {
    static create(value) {
        let node = super.create()
        node.setAttribute('src', value.url)
        node.setAttribute('width', value.width)
        node.setAttribute('height', value.height)
        node.setAttribute('class', 'ql-video')
        return node;
    }

    static value(node) {
        return {
            url: node.getAttribute('src'),
            width: node.getAttribute('width'),
            height: node.getAttribute('height')
        };
    }
}

VideoBlot.blotName = 'simpleVideo'
VideoBlot.tagName = 'iframe'

export default VideoBlot