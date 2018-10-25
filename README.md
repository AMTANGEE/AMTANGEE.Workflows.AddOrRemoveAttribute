# AMTANGEE Add or Remove Attribute Workflow Plugin

This workflow plugin parses incoming emails for a given subject. 
If the email subject starts with 'Subscribe:' followed by a guid or name, the plugin removes the attribute from the assigned contact for this email by its guid or name. Otherwise, if the subject starts with 'Unsubscribe:' followed by a guid or name the plugin removes the attribute from the assigned contact.

## Requirements

* AMTANGEE Partner Key for signing the assembly
* .NET Framework 3.5
* AMTANGEE Workflow Service

## Feedback

* Send us an email at support@amtangee.com
* File an issue here in [GitHub](https://github.com/amtangee/Workflows.AddOrRemoveAttribute/issues)

## License

Copyright (c) AMTANGEE AG - https://www.amtangee.com

Licensed under the [MIT](LICENSE) License.