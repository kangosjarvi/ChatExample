namespace MauiApp1.Components.Pages;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public partial class Home : ComponentBase
{
    [Inject] IJSRuntime JS { get; set; }
    private IList<DtoMessage> Messages = new List<DtoMessage>();
    private string NewMessage = "";
    private string OtherUserName = "";
    private Guid LoggedInUserId;
    private Guid OtherUserId { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // After initial render, ensure padding and scroll are correct
        await JS.InvokeVoidAsync("chatHelpers.adjustMessagesBottomPadding");
        await JS.InvokeVoidAsync("chatHelpers.scrollToBottom");
    }

    private async Task SendMessage()
    {
        if (!string.IsNullOrWhiteSpace(NewMessage))
        {
            var message = new DtoMessage
            {
                Sender_Id = LoggedInUserId,
                Receiver_Id = OtherUserId,
                Content = NewMessage,
                image_data = Array.Empty<byte>()
            };

            Messages.Add(message);
            NewMessage = string.Empty;

            // Trigger UI update and then scroll
            StateHasChanged();
            // Wait for DOM to update before scrolling
            await JS.InvokeVoidAsync("chatHelpers.adjustMessagesBottomPadding");
            await JS.InvokeVoidAsync("chatHelpers.scrollToBottom");
        }
    }

    private async Task SendImageMessage(byte[] imageBytes)
    {
        var message = new DtoMessage
        {
            Sender_Id = LoggedInUserId,
            Receiver_Id = OtherUserId,
            Content = string.Empty,
            image_data = imageBytes
        };

        Messages.Add(message);

        StateHasChanged();
        await JS.InvokeVoidAsync("chatHelpers.adjustMessagesBottomPadding");
        await JS.InvokeVoidAsync("chatHelpers.scrollToBottom");
    }

    private async Task CaptureImage()
    {
        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            // Process photo here and call SendImageMessage(...)
        }
        catch (Exception)
        {
            // Handle exceptions
        }
    }

    public async Task ProcessAndUploadImage()
    {
        // Pick and process image, then call SendImageMessage(...)
    }
}
public class DtoMessage
{
    public Guid Sender_Id { get; set; }
    public Guid Receiver_Id { get; set; }
    public string Content { get; set; }
    public byte[] image_data { get; set; } = Array.Empty<byte>();
    public int image_size { get; set; } = 0;
    public DateTime Sent_At { get; set; }
    public bool Is_Mine { get; set; }
}
