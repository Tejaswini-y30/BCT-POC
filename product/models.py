from django.db import models

# Create your models here.
class Products(models.Model):
    productId=models.BigAutoField(primary_key=True)
    productName=models.CharField(max_length=100)
    productDescription=models.CharField(max_length=10000)
    productCategory=models.CharField(max_length=100)
    productBrand=models.CharField(max_length=100)
    productSize=models.CharField(max_length=10)
    productGender=models.CharField(max_length=10)
    productPrice=models.IntegerField()
    productImg=models.ImageField(upload_to='pictures/%Y/%m/%d/', max_length=255, null=True, blank=True)

    def __str__(self):
        return self.productName
