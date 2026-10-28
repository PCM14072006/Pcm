var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    var mp = options.ModelBindingMessageProvider;
    mp.SetValueMustNotBeNullAccessor(_ => "Trường này bắt buộc phải được nhập");
    mp.SetMissingBindRequiredValueAccessor(f => $"Thiếu giá trị cho {f}");
    mp.SetMissingKeyOrValueAccessor(() => "Bắt buộc phải nhập giá trị");
    mp.SetAttemptedValueIsInvalidAccessor((v, f) => $"Giá trị '{v}' không hợp lệ cho {f}");
    mp.SetUnknownValueIsInvalidAccessor(f => $"Giá trị không hợp lệ cho {f}");
    mp.SetNonPropertyAttemptedValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ");
    mp.SetNonPropertyUnknownValueIsInvalidAccessor(() => "Giá trị không hợp lệ");
    mp.SetValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ");
    mp.SetValueMustBeANumberAccessor(f => $"{f} phải là số thực");
    mp.SetNonPropertyValueMustBeANumberAccessor(() => "Giá trị phải là số thực");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.MapControllerRoute(
    name: "student-list",
    pattern: "Admin/Student/List",
    defaults: new { controller = "Student", action = "Index" }
);

app.MapControllerRoute(
    name: "student-add",
    pattern: "Admin/Student/Add",
    defaults: new { controller = "Student", action = "Create" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();