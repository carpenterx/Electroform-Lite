using AutoMapper;
using ElectroformLite.API.Controllers;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Commands.DeleteDataType;
using ElectroformLite.Application.DataTypes.Commands.EditDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypes;
using ElectroformLite.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ElectroformLite.APITests;

public class DataTypeControllerTests
{
    private readonly Mock<IMediator> _mockMediator = new();
    private readonly Mock<IMapper> _mockMapper = new();

    [Fact]
    public async void GetDataTypes_GetDataTypesQuery_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<GetDataTypesQuery>(), It.IsAny<CancellationToken>())).Verifiable();
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.GetDataTypes();

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<GetDataTypesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GetDataType_GetDataTypeQuery_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<GetDataTypeQuery>(), It.IsAny<CancellationToken>())).Verifiable();
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.GetDataType(Guid.Empty);

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<GetDataTypeQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void CreateDataType_CreateDataTypeCommand_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<CreateDataTypeCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        _mockMapper.Setup(m => m.Map<DataTypeDto>(It.IsAny<DataType>())).Returns(new DataTypeDto());
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.CreateDataType("Type");

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<CreateDataTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void DeleteDataType_DeleteDataTypeCommand_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<DeleteDataTypeCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.DeleteDataType(Guid.Empty);

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<DeleteDataTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void UpdateDataType_EditDataTypeCommand_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<EditDataTypeCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        _mockMapper.Setup(m => m.Map<DataTypeDto>(It.IsAny<DataType>())).Returns(new DataTypeDto());
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.UpdateDataType(Guid.Empty, new DataTypeDto());

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<EditDataTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void DeleteDataType_Returns_NoContent()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<DeleteDataTypeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new DataType("Type"));
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        NoContentResult noContentResult = (NoContentResult)await controller.DeleteDataType(Guid.Empty);

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
    }

    [Fact]
    public async void CreateDataType_Returns_CreatedAtAction()
    {
        // Arrange
        string type = "Type";
        DataType dataType = new(type);
        Guid dataTypeId = Guid.NewGuid();
        DataTypeDto dataTypeDto = new() { Id = dataTypeId, Value = type };
        CreateDataTypeCommand createDataTypeCommand = new(type);
        _mockMediator
            .Setup(m => m.Send(It.Is<CreateDataTypeCommand>(c => c.TypeValue == type), It.IsAny<CancellationToken>()))
            .ReturnsAsync(dataType);
        _mockMapper.Setup(m => m.Map<DataTypeDto>(It.Is<DataType>(d => d == dataType))).Returns(dataTypeDto);
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        CreatedAtActionResult createdAtActionResult = (CreatedAtActionResult)await controller.CreateDataType(type);

        // Assert
        Assert.Equal(dataTypeDto, createdAtActionResult.Value);
        Assert.Equal(dataTypeDto.Id, createdAtActionResult.RouteValues[nameof(dataTypeDto.Id)]);
        Assert.Equal(StatusCodes.Status201Created, createdAtActionResult.StatusCode);
    }

    [Fact]
    public async void GetDataType_GetDataTypeQuery_WithCorrectId_IsCalled()
    {
        // Arrange
        Guid expectedId = Guid.NewGuid();
        Guid actualId = Guid.Empty;
        _mockMediator
            .Setup(m => m.Send(It.IsAny<GetDataTypeQuery>(), It.IsAny<CancellationToken>()))
            .Returns<GetDataTypeQuery, CancellationToken>( async (q, t) =>
            {
                actualId = q.DataTypeId;
                DataType dataType = new("Type")
                {
                    Id = q.DataTypeId
                };
                return await Task.FromResult(dataType);
            });
        _mockMapper
            .Setup(m => m.Map<DataTypeDto>(It.Is<DataType>(d => d.Id == expectedId)))
            .Returns(new DataTypeDto
            {
                Id = expectedId,
                Value = "Type"
            });

        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        var response = await controller.GetDataType(expectedId);
        var result = response.Result as OkObjectResult;

        // Assert
        Assert.Equal(expectedId, ((DataTypeDto)result.Value).Id);
        Assert.Equal(expectedId, actualId);
    }
}